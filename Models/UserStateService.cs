using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using BasicTools;
using System.Data.SqlClient;

namespace Models
{
    /// <summary>
    /// 根据id查询用户当前状态
    /// </summary>
    public static partial class UserStateService
    {
        public static UserState GetUserStateById(int id)
        {
            const string sql = @"SELECT * FROM UserStates WHERE Id = @id";
            try
            {
                SqlDataReader reader = SqlDBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    UserState userState = new UserState();
                    userState.id = (int)reader["Id"];
                    userState.name = (string)reader["Name"];
                    reader.Close();
                    return userState;
                }
                else
                {
                    reader.Close();
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                Log.WriteLog(new Error("数据库业务错误","获取数据失败",ex));
                return null;
            }
        }
    }
}
