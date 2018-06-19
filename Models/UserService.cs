using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DLL;
using System.Data;

namespace Models
{
    /// <summary>
    /// 局部类
    /// </summary>
    public static partial class UserService
    {
        private static User GetReaderUser(SqlDataReader reader)
        {
            if (reader.Read())
            {
                int userStateId;
                int userRoleId;
                User user = new User();
                user.id = (int)reader["id"];
                user.loginId = (string)reader["LoginId"];
                user.loginPwd = (string)reader["LoginPwd"];
                user.name = (string)reader["Name"];
                user.address = (string)reader["Address"];
                user.phone = (string)reader["Phone"];
                user.mail = (string)reader["Mail"];

                if (reader[9] != DBNull.Value)
                    user.LastOnlineTime = (DateTime)reader["LastOnlineTime"];
                else
                    user.LastOnlineTime = DateTime.Now;

                if (reader[10] != DBNull.Value && ((string)reader[10]).Trim() != "")
                    user.PerSonalSynopsis = (string)reader["PersonalSynopsis"];
                else
                    user.PerSonalSynopsis = "Ta没有写个性签名哦!";

                userRoleId = (int)reader["UserRoleId"];
                userStateId = (int)reader["UserStateId"];

                reader.Close();

                user.userState = UserStateService.GetUserStateById(userStateId);
                user.userRole = UserRoleService.GetUserRoleById(userRoleId);
                user.UserMessageBoard = UserMessageBoardService.GetUserMessageBoardById(user);

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 根据登录账号获取用户信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static User GetUserByLoginId(string loginId)
        {
           const string sql = "SELECT * FROM Users WHERE LoginId = @LoginId";

            using(SqlDataReader reader = SqlDBHelper.GetReader(sql,new SqlParameter("@LoginId",loginId)))
                return GetReaderUser(reader);
        }

        /// <summary>
        /// 根据编号获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            const string sql = "SELECT * FROM Users WHERE Id = @Id";

            using (SqlDataReader reader = SqlDBHelper.GetReader(sql, new SqlParameter("@Id", id)))
                return GetReaderUser(reader);
          
        }

        public static int DelUserById(int id)
        {
            string sql = "DELETE FROM [dbo].[Users] WHERE [Id] = " + id;
            return SqlDBHelper.ExecuteCommand(sql);
        }

        public static User AddUser(User user)
        {
            string sql = "INSERT Users" + "(LoginId,LoginPwd,Name,Address,Phone,Mail,UserRoleId,UserStateId,LastOnlineTime,PersonalSynopsis) VALUES" + "(@LoginId,@LoginPwd,@Name,@Address,@Phone,@Mail,@UserRoleId,@UserStateId,@LastOnlineTime,@PersonalSynopsis)";
            sql += "; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserStateId",user.userState.id),
                new SqlParameter("@UserRoleId",user.userRole.id),
                new SqlParameter("@LoginId",user.loginId),
                new SqlParameter("@LoginPwd",user.loginPwd),
                new SqlParameter("@Name",user.name),
                new SqlParameter("@Address",user.address),
                new SqlParameter ("@Phone",user.phone),
                new SqlParameter("@Mail",user.mail),
                new SqlParameter("@LastOnlineTime",DateTime.Now),
                new SqlParameter("@PersonalSynopsis","还没有个性签名哦！")
            };
            int id = SqlDBHelper.GetScalar(sql,para);
            return GetUserById(id);
        }

        /// <summary>
        /// 设置默认状态(离线)
        /// </summary>
        /// <param name="id"></param>
        public static void ModifyStatus(int id)
        {
            const string sql = "UPDATE Users SET UserStateId = @UserStateId WHERE Id = @id";
            const int STATUSCODE_OFFLINE = 1; //离线

            SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{
                new SqlParameter("@Id",id),
                new SqlParameter("@UserStateId", STATUSCODE_OFFLINE)
            });
        }
        /// <summary>
        /// 设置状态为赋予的状态值1离线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stateCode"></param>
        public static User ModifyStatus(int id, int stateCode)
        {
            const string sql = "UPDATE Users SET UserStateId = @UserStateId WHERE Id = @Id";
            SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{

                new SqlParameter("@Id",id),
                new SqlParameter("@UserStateId",stateCode)

            });
            return GetUserById(id);
        }

        public static DateTime ModifyUserOnlineTime(int id)
        {
            const string sql = "UPDATE Users SET LastOnlineTime = @LastOnlineTime WHERE Id = @Id";
            DateTime dtNow = DateTime.Now;
            SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{

                new SqlParameter("@LastOnlineTime",dtNow),
                new SqlParameter("@Id",id)

            });
            return dtNow;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public static bool ModifyUser(int id,string loginID,string loginPwd)
        {
            const string sql = "UPDATE Users SET LoginId = @LoginId , LoginPwd = @LoginPwd WHERE Id =@Id";
            int i = SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{
                new SqlParameter("@LoginId",loginID),
                new SqlParameter("@LoginPwd",loginPwd),
                new SqlParameter("@Id",id)
            });

            if (i > 0)
            {
                return true;
            }
            else
                return false;
            
        }
        public static bool ModifyUser(int id, string loginPwd)
        {
            const string sql = "UPDATE Users SET LoginPwd = @LoginPwd WHERE Id = @id";
            int i = SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{
                new SqlParameter("@LoginPwd",loginPwd),
                new SqlParameter("@Id",id)
            });
            if (i > 0)
            {
                return true;
            }else
                return false;
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address">地址</param>
        /// <param name="phone">手机号码</param>
        /// <param name="perSanlSynopsis">个人简介</param>
        /// <param name="mail">邮箱</param>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public static User ModifyBaseInfo(int id,string address,string phone,string perSanlSynopsis,string mail,string name)
        {
            const string sql = "UPDATE Users SET Address = @address,Phone = @phone,Name = @name,Mail = @mail,PersonalSynopsis = @personalSynopsis WHERE Id = @id";
          
            return ModifyFactory(sql,id,new SqlParameter[]{
                new SqlParameter("@address",address),
                new SqlParameter("@phone",phone),
                new SqlParameter("@personalSynopsis",perSanlSynopsis),
                new SqlParameter("@mail",mail),
                new SqlParameter("@name",name),
                new SqlParameter("@id",id)
            });
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address">地址</param>
        /// <param name="phone">手机号码</param>
        /// <param name="perSanlSynopsis">个人简介</param>
        /// <param name="mail">邮箱</param>
        /// <param name="name">姓名</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public static int ModifyBaseInfo(int id, string address, string phone, string perSanlSynopsis, string mail, string name,int role)
        {
            const string sql = "UPDATE Users SET Address = @address,Phone = @phone,Name = @name,Mail = @mail,PersonalSynopsis = @personalSynopsis,UserRoleId = @role WHERE Id = @id";



            return SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{
                new SqlParameter("@role",role),
                new SqlParameter("@address",address),
                new SqlParameter("@phone",phone),
                new SqlParameter("@personalSynopsis",perSanlSynopsis),
                new SqlParameter("@mail",mail),
                new SqlParameter("@name",name),
                new SqlParameter("@id",id)
            });
        }
        public static User ModifyFactory(string sql,int id, SqlParameter[] parameter)
        {
            int i = SqlDBHelper.ExecuteCommand(sql, parameter);
            if (i > 0)
            {
                return GetUserById(id);
            }
            else
                return null;
        }
        public static DataTable GetAllUsersInfo()
        {
            const string sql = "SELECT   dbo.[Users].[Id], dbo.[Users].[LoginId], dbo.[Users].[Name], dbo.[Users].[Address], dbo.[Users].[Phone], dbo.[Users].[Mail], dbo.UserRoles.[Name] AS RolesName, dbo.UserStates.[Name] AS StatesName, dbo.[Users].LastOnlineTime, dbo.[Users].[PersonalSynopsis]"   
                             +  "FROM      dbo.[Users] INNER JOIN dbo.UserRoles ON dbo.[Users].[UserRoleId] = dbo.[UserRoles].[Id] INNER JOIN  dbo.[UserStates] ON dbo.[Users].[UserRoleId] = dbo.UserStates.[Id]";
            return SqlDBHelper.GetDataTable(sql);
        }
    }
}
