/*
 * 数据库工具类
 * 应该设置统一配置文件
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DLL
{
    [Serializable()]
    public static class SqlDBHelper
    {
        private static readonly object olock = new object();
        private static SqlConnection _connection;

        /// <summary>
        /// 连接数据库
        /// </summary>
        public static SqlConnection connection
        {
            get
            {
                string connectionString = DBConfig.DBConnection;

                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionString);
                    _connection.Open();
                }
                else
                {
                    switch (_connection.State)
                    {
                        case System.Data.ConnectionState.Closed:
                            _connection.Open();
                            break;
                        case System.Data.ConnectionState.Broken:// 如果连接对象存在，但状态是“与数据源连接中断”，则重启数据库
                            _connection.Close();
                            _connection.Open();
                            break;
                        default:
                            break;
                    }
                }
                return _connection;
            }
        }

        /// <summary>
        /// 执行一条sql语句，返回一个影响行数
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, connection);
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        /// <summary>
        /// 执行一条带参数的sql语句，返回一个影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        public static int ExecuteCommand(string sql,params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.AddRange(values);

            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行一条带参数的sql语句，返回一个（首行首列）int类型的查询结果
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, connection);

            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行一条带参数的sql语句，返回一个（首行首列）int类型的查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetScalar(string sql, params SqlParameter[] value)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddRange(value);

            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行一条sql语句，查询结果以SqldataReader 的形式返回
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        /// <summary>
        /// 执行一条带参数的sql语句，查询结果以SqldataReader 的形式返回
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] value)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddRange(value);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        /// <summary>
        /// 获取离线数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql,params SqlParameter[] value)
        {

            //创建命令对象
            SqlCommand comm = new SqlCommand();
            //设置命令对象的数据源连接对象，
            //进行的操作（Sql语句，表明，存储过程）
            //以及操作的类型
            comm.Connection = connection;
            comm.CommandText = sql;
            //添加操作所用的参数
            if (value != null)
            {
                foreach (SqlParameter para in value)
                    comm.Parameters.Add(para);
            }
            //创建离线内存表
            DataTable dataTable = new DataTable();
            //创建Adapter对象，并利用查询命令的返回结果填充离线内存表
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = comm;
            ad.Fill(dataTable);
            //释放相关资源
            comm.Parameters.Clear();
            comm.Dispose();
            //返回结果集
            return dataTable;
        }
	    public static DataTable GetDataTable(string sql)
        {
            lock (olock)
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                return dt;
            }
        }	 
    }
}
