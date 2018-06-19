using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DLL;
using BasicTools;
using System.Data;

namespace Models
{
    public static partial class UserRoleService
    {
        /// <summary>
        /// 根据ID 查询用户当前的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserRole GetUserRoleById(int id)
        {
            const string sql = "SELECT * FROM UserRoles WHERE Id = @Id";
            SqlDataReader reader = SqlDBHelper.GetReader(sql, new SqlParameter("@Id", id));
            return GetUserRole(reader);
        }

        public static DataTable GetRoles()
        {
            const string sql = "SELECT * FROM UserRoles";

            return SqlDBHelper.GetDataTable(sql);
        }

        private static UserRole GetUserRole(SqlDataReader reader)
        {
            try
            {
                if (reader.Read())
                {
                    UserRole userRole = new UserRole();
                    userRole.id = (int)reader["id"];
                    userRole.name = (string)reader["name"];
                    reader.Close();
                    return userRole;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                reader.Close();
                Log.WriteLog(new Error("数据库业务错误URS 0x7EE7", "获取数据失败", ex));
                return null;
            }
        }
    }
}
