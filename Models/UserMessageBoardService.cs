/**
 * 作者：Galoliy
 * 完成日期：2018/5/10
 * **/
using System;
using System.Collections.Generic;
using DLL;
using BasicTools;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace Models
{
    public class UserMessageBoardService
    {
        private static List<UserMessageBoard> _list;
        public static List<UserMessageBoard> listAllMB
        {
            get 
            {
                _list = GetAllUserMessageBoard();

                return _list;
           }
           private set { }
        }
        /// <summary>
        /// 根据id获取留言板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<UserMessageBoard> GetUserMessageBoardById(User user)
        {
            if (user != null && user.id <= 0)
            {
                List<UserMessageBoard> newUMB = listAllMB;
                //var linq = from x in list where x.user.id = id select x;
                return newUMB; 
                    //(List<UserMessageBoard>)newUMB.OrderBy(x => x.ComDateTime).Where(x => x.user.id == user.id).Select(x => x);
            }
            else
                return null;
        }
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="title">标题</param>
        /// <param name="article">内容</param>
        /// <param name="url">链接</param>
        /// <param name="comTime">发表时间</param>
        /// <param name="categoriesId">分类ID</param>
        /// <returns></returns>
        public static bool AddUserMessageBoard(int userId,string title,string article,string url,DateTime comTime,int categoriesId)
        {
            const string sql = "INSERT INTO [dbo].[UserMessageBoard]([Id] ,[Title],[Article],[URL],[ComTime],[CategoriesId]) VALUES (@userId,@title,@article,@url,@comTime,@categoriesId)";
            SqlParameter[] parameter = new SqlParameter[]{

                new SqlParameter("@userId",userId),
                new SqlParameter("@title",title),
                new SqlParameter("@article",article),
                new SqlParameter("@url",url),
                new SqlParameter("@comTime",comTime),
                new SqlParameter("@categoriesId",categoriesId)

            };

            if (SqlDBHelper.ExecuteCommand(sql,parameter) > 0)
            {
                return true;
            }
            else
                return false;
            
        }

        public static int UpdataMessageBoardByDataTable(int MBId, string title, string article, string url, DateTime comTime, int categoriesId)
        {
            const string sql = "SELECT   UserMessageBoard.MessageBoardId,[Users].[Name], UserMessageBoard.[Title],UserMessageBoard.[Article],UserMessageBoard.[URL], UserMessageBoard.[ComTime], MessageBoardCategories.[CategoriesTitle]"
                            + "FROM      [UserMessageBoard] INNER JOIN [Users] ON UserMessageBoard.[Id] = Users.[Id] INNER JOIN  [MessageBoardCategories] ON UserMessageBoard.[CategoriesId] = MessageBoardCategories.[CategoriesId]";
            return 1;
        }

        public static int DeleteMessageBoardByID(string id)
        {
            string sql = "DELETE FROM [UserMessageBoard] WHERE MessageBoardId = '" + id + "'";

            return SqlDBHelper.ExecuteCommand(sql);
        }

        public static DataTable GetMessageBoardIn()
        {
            const string sql = "SELECT   UserMessageBoard.MessageBoardId,[Users].[Name], UserMessageBoard.[Title],UserMessageBoard.[Article],UserMessageBoard.[URL], UserMessageBoard.[ComTime], MessageBoardCategories.[CategoriesTitle]"
                             + "FROM      [UserMessageBoard] INNER JOIN [Users] ON UserMessageBoard.[Id] = Users.[Id] INNER JOIN  [MessageBoardCategories] ON UserMessageBoard.[CategoriesId] = MessageBoardCategories.[CategoriesId]";
                         return SqlDBHelper.GetDataTable(sql);
        }

        public static DataTable GetMessageBoard()
        {
            const string sql = "SELECT * FROM UserMessageBoard";
            return SqlDBHelper.GetDataTable(sql);
        }

        public static DataTable GetCategories()
        {
            const string sql = "SELECT * FROM MessageBoardCategories";
             return SqlDBHelper.GetDataTable(sql);
        }

        private static List<UserMessageBoard> GetAllUserMessageBoard()
        {
            DataTable reader = GetMessageBoard();
            List<UserMessageBoard> newList = new List<UserMessageBoard>();
            try
            {
                for (int i = 0; i < reader.Rows.Count; i++)
                {
                    UserMessageBoard userMessageBoard = new UserMessageBoard(

                        (Guid)reader.Rows[i]["MessageBoardId"],  //编号
                        (string)reader.Rows[i]["Title"], //标题
                        (string)reader.Rows[i]["Article"], //内容
                        (string)reader.Rows[i]["URL"], //URL   
                        (DateTime)reader.Rows[i]["ComTime"]    //发布时间
                    );
                    try
                    {
                        userMessageBoard.MessageBoardCategories = MessageBoardCategoriesService.GetMessageBoradCategories((int)reader.Rows[i]["CategoriesId"]);
                        userMessageBoard.user = UserService.GetUserById((int)reader.Rows[i]["Id"]);

                        UserMessageBoard.MBCategories = MessageBoardCategoriesService.GetMBCategories();

                        newList.Add(userMessageBoard);
                    }
                    catch (Exception ex)
                    {
                        
                       
                    }
                  
                }
                reader.Dispose();
                newList.Sort((x, y) => y.ComDateTime.CompareTo(x.ComDateTime));
                return newList;
            }
            catch (Exception ex)
            {
                Log.WriteLog(new Error("数据库业务错误UMBS 0x6EE7", "获取数据失败", ex));
                if (reader != null)
                {
                    reader.Dispose();
                }
                throw ex;
                return null;
            }
        }

        public static int ModifyBaseInfo(string MBId, string title, string content, string linkURL, int categroiesId)
        {
            const string sql = "UPDATE UserMessageBoard SET Title = @title,Article = @article,URL = @url,CategoriesId = @categroiesId WHERE MessageBoardId = @MBId";

            return SqlDBHelper.ExecuteCommand(sql, new SqlParameter[]{
                new SqlParameter("@title",title),
                new SqlParameter("@article",content),
                new SqlParameter("@url",linkURL),
                new SqlParameter("@categroiesId",categroiesId),
                new SqlParameter("@MBId",MBId),
            });
        }
    }
}
