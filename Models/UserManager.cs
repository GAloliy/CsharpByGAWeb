
/*
 * 用户管理类
 * 尚未完善
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicTools;

namespace Models
{
    public static partial class UserManager
    {
        /// <summary>
        /// 添加一个用户
        /// </summary>
        public static User AddUser(User user)
        {
            if (user.userState == null)
                user.userState = UserStateManager.GetDefaultUserState();

            if (user.userRole == null)
                user.userRole = UserRoleManager.GetDefaultUserRole();
            //调用数据访问层的AddUser注册用户
            return UserService.AddUser(user);
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        public static bool AdminLogin()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        public static void DeleteUser()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        public static void DeleteUserById()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有普通用户
        /// </summary>
        public static IList<User> GetAllNormalUsers()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询所有普通用户
        /// </summary>
        public static IList<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据用户id查询 用户
        /// </summary>
        public static User GetUserById(int id)
        {
            return UserService.GetUserById(id);
        }
        /// <summary>
        /// 根据用户id查询状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserState GetUserStateById(int id)
        {
            return GetUserById(id).userState;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        public static bool Login(string loginId,string loginPwd,out User validUser)
        {
            User user = UserService.GetUserByLoginId(loginId);
            if (user == null)
	        {
                validUser = null;
                return false;
	        }

            if (Encryption.CustomExclusiceOrEncrytion(user.loginPwd).Equals(loginPwd))
            {
                user.LastOnlineTime = UserService.ModifyUserOnlineTime(user.id);
                validUser = user;
                return true;
            }
            else
            {
                validUser = null;
                return false;
            }

        }

        /// <summary>
        /// 查询用户名是否已经存在
        /// </summary>
        public static bool LoginIdExists(string loginId)
        {
            if (UserService.GetUserByLoginId(loginId) == null)
                return false;
            return true;
        }
        public static bool IdExists(int id)
        {
            if (UserService.GetUserById(id) == null)
                return false;
            return true;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        public static bool ModifyUser(int id,string loginID,string loginPwd)
        {
            return UserService.ModifyUser(id,loginID,loginPwd);
        }
        public static bool ModifyUser(int id,string loginPwd)
        {
            return UserService.ModifyUser(id,loginPwd);
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        public static User ModifyBasicInfo(int id,string address,string phone,string perSanlSynopsis,string mail,string name)
        {
            return UserService.ModifyBaseInfo(id, address, phone, perSanlSynopsis, mail, name);
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        public static int ModifyBasicInfo(int id, string address, string phone, string perSanlSynopsis, string mail, string name,int role)
        {
            return UserService.ModifyBaseInfo(id, address, phone, perSanlSynopsis, mail, name,role);
        }

        /// <summary>
        /// 修改用户登录时间
        /// </summary>
        public static DateTime ModifyUserOnlineTime(int id)
        {
            return UserService.ModifyUserOnlineTime(id);
        }

        /// <summary>
        /// 根据id修改用户状态为1(离线)
        /// </summary>
        public static void ModifyUserStatusById(int id)
        {
            if (IdExists(id))
                UserService.ModifyStatus(id);
        }
        public static void ModifyUserStatusById(int id, int stateCode)
        {
            if (IdExists(id))
                UserService.ModifyStatus(id, stateCode);

        }
        /// <summary>
        /// 注册新用户
        /// </summary>
        public static bool Register(User user)
        {
            if (LoginIdExists(user.loginId))
            {
                return false;
            }
            else
            {
                AddUser(user);
                return true; 
            }
        }
    }
}
