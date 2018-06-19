using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using DLL;
using System.Data;

namespace Models
{
    public class MessageBoardCategoriesService
    {
        /// <summary>
        /// 获取留言板总数信息
        /// </summary>
        /// <returns></returns>
        public static List<MBCategories> GetMBCategories()
        {
            const string sql = "SELECT UserMessageBoard.CategoriesId,MessageBoardCategories.CategoriesTitle,count(*) as CategoriesSum " +
                                " FROM MessageBoardCategories " +
                                " INNER JOIN UserMessageBoard " +
                                " ON UserMessageBoard.CategoriesId = MessageBoardCategories.CategoriesId " +
                                " GROUP BY UserMessageBoard.CategoriesId,MessageBoardCategories.CategoriesTitle " +
                                " ORDER BY CategoriesSum DESC ";
            List<MBCategories> mbCategoriesList = new List<MBCategories>();
            DataTable reader = SqlDBHelper.GetDataTable(sql);

            if (reader != null)
            {
                for (int i = 0; i < reader.Rows.Count; i++)
                {
                    MBCategories mbCategories = new MBCategories();
                    mbCategories.cetegoriesId = (int)reader.Rows[i]["CategoriesId"];
                    mbCategories.cetegoriesTitle = (string)reader.Rows[i]["CategoriesTitle"];
                    mbCategories.sum = (int)reader.Rows[i]["CategoriesSum"];
                    mbCategoriesList.Add(mbCategories);
                }
                reader.Dispose();
                return mbCategoriesList;
            }
            else
            {
                return null;

            }
          
        }
        /// <summary>
        /// 感觉留言板Id获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MessageBoardCategories GetMessageBoradCategories(int id)
        {
            const string sql = "SELECT * FROM MessageBoardCategories WHERE CategoriesId = @Id";
            SqlDataReader reader = SqlDBHelper.GetReader(sql, new SqlParameter("@Id", id));
            return MBCFactory(reader);
        }

        private static MessageBoardCategories MBCFactory(SqlDataReader reader)
        {
            if (reader.Read())
            {
                MessageBoardCategories mbc = new MessageBoardCategories(
                    (int)reader["CategoriesId"],
                    (string)reader["CategoriesTitle"]
                );
                reader.Close();
                return mbc;
            }
            else
            {
                reader.Close();
                return null;
            }
            

        }
    }
}
