using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DLL
{
    public sealed class DBConfig
    {
        public static string DBConnection
        {
            get
            {
                string _DBConnection = ConfigurationManager.AppSettings["DBConnection"].ToString();
                if (_DBConnection.Length > 0)
                    return _DBConnection;
                else
                {
                    return null;
                }
              
            }
        }

        public static DataBaseTypeEnum DBType
        {
            get
            {
                DataBaseTypeEnum db = DataBaseTypeEnum.Unknown;
                string _DBType = ConfigurationManager.AppSettings["DBType"].ToString().ToUpper();
                switch (_DBType)
                {
                    case"SQLSERVER":
                        db = DataBaseTypeEnum.SQLServer;
                        break;
                    case"ORACLE":
                        db = DataBaseTypeEnum.Oracle;
                        break;
                    case"ACCESS":
                        db = DataBaseTypeEnum.Access;
                        break;
                    default:
                        break;
                }
                return db;
            }
        }

    }

    /// <summary>
    /// 数据库枚举
    /// </summary>
    [Serializable]
    public enum DataBaseTypeEnum
    {
        /// <summary>
        /// 未知抛出异常
        /// </summary>
        Unknown,
        SQLServer,
        Oracle,
        Access
    }
}
