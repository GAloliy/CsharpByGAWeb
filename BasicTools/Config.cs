
/*
 * 系统文件配置 
 作者：@GAloliy
 完成日期：18-03-27
 摘要说明：从配置文件读取相关设置
 */
using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Xml;

namespace BasicTools
{
    /// <summary>
    /// 从配置文件读取相关设置
    /// </summary>
    public sealed class Config
    {
        /// <summary>
        ///是否显示详细的错误信息
        /// </summary>
        public static bool ShowErrors
        {
            get
            {
                string isShowErrors = ConfigurationManager.AppSettings["ShowErrors"].ToUpper().ToString().Trim();
                return isShowErrors.Equals("TRUE") ? true : false;
            }
        }
        /// <summary>
        /// 是否启用日志功能
        /// </summary>
        public static bool LogEnabled
        {
            get
            {
                string isLogEnablead = ConfigurationManager.AppSettings["LogEnabled"].ToUpper().ToString().Trim();
                return isLogEnablead.Equals("TRUE") ? true : false;
            }
        }
        /// <summary>
        /// 日志文件名
        /// </summary>
        public static string LogFile
        {
            get
            {
                string path = HttpContext.Current == null ? AppDomain.CurrentDomain.BaseDirectory + @"\Subscription" : HttpContext.Current.Server.MapPath(@"/Subscription"); 
                string filePath = HttpContext.Current == null?  AppDomain.CurrentDomain.BaseDirectory + @"\Subscription\Log.txt" : HttpContext.Current.Server.MapPath(@"/Subscription/Log.txt");

                if (FileOperation.IsDirectoryInfoExists(path) == false)
                    FileOperation.DirectoryInfoCreate(path);

                if (FileOperation.IsFileExists(filePath) == false)
                    FileOperation.WritFile(filePath,"---------------- 日志(" + DateTime.Now.ToString() + ") --------------");

                return filePath;
            }
        }
        /// <summary>
        /// 日志文件大小
        /// </summary>
        public static string LogMaxSize
        {
            get
            {
                string size = ConfigurationManager.AppSettings["LogMaxSize"].ToString().Trim();
                if (size.Length <= 0)
                {
                    size = "10M";
                }
                return size;
            }
        }
        /// <summary>
        /// 敏感词文本路径
        /// </summary>
        public static string BadWords
        {
            get 
            {
                string path =AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["BlockWords"].ToString().Trim();
                if (path.Length <= 0)
                {
                    //Log.WriteLog(new Error("警告：敏感词设置有误!返回默认路径并包含了文本文件名"));
                    path = AppDomain.CurrentDomain.BaseDirectory + @"\Controls\Tools\BadWords.ini";
                }
                return path;
            }
        }
        /// <summary>
        /// 线程池大小,默认1000
        /// </summary>
        public static int ThreadPoolSize
        {
            get
            {
                int size = 1000;
                bool reult = Int32.TryParse(ConfigurationManager.AppSettings["ThreadPoolSize"].ToString(),out size);

                return size;
            }
        }

        public static string Api_Key
        {
            get
            {
                string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString().Trim();
                if (apiKey.Length > 0)
                    return apiKey;
                else
                {
                    Log.WriteLog(new Error("没有设置APIKEY"));
                    return string.Empty;
                }
            }
        }

        public static string Secret_Key
        {
            get
            {
                string secretKey = ConfigurationManager.AppSettings["SecretKey"].ToString().Trim();
                if (secretKey.Length > 0)
                    return secretKey;
                else
                {
                    Log.WriteLog(new Error("没有设置SECRETKEY"));
                    return string.Empty;
                }

            }
        }
        public static string App_Id
        {
            get
            {
                string App_Id = ConfigurationManager.AppSettings["App_Id"].ToString().Trim();
                if (App_Id.Length > 0)
                    return App_Id;
                else
                {
                    Log.WriteLog(new Error("没有设置App_Id"));
                    return string.Empty;
                }

            }
        }

        
        public static bool EncryptionConfig
        {
            get
            {
                string encrytionConfig = ConfigurationManager.AppSettings["EncryptionConfig"].ToString().ToUpper().Trim();

                if (encrytionConfig.Length <= 0)
                {
                    encrytionConfig = "FALSE";
                }
                /*string encrytionInit = ConfigurationManager.AppSettings["EncryptionInit"].ToString().ToUpper().Trim();                
                if (encrytionConfig.Length < 0 || encrytionConfig == string.Empty)
                {
                    encrytionConfig = "FALSE";   
                }
                if (encrytionConfig.Equals("TRUE") && encrytionInit.Equals("FALSE"))
                {
                    //StartEncryptionConfig();
                    encrytionInit = "TRUE";
                }*/

                return encrytionConfig.Equals("TRUE") ? true : false;
            }
        }

        private static void StartEncryptionConfig()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "Web.config";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configPath);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("/configuration/appSettings").ChildNodes;

            XmlElement xe = null;
            foreach (var xn in nodeList)
            {

                xe = xn as XmlElement;
                if (xe != null)
                {
                    string attrName = xe.GetAttribute("key");  
                    
                    switch (attrName)
                    {
                        case "EncryptionInit":
                            xe.SetAttribute("value","TRUE");
                            break;
                        case "DBConnection":
                            XmlElementFactory(xe);
                            break;
                        case "DBType":
                            XmlElementFactory(xe);
                            break;
                        case "LogEnabled":
                            XmlElementFactory(xe);
                            break;
                        case "LogMaxSize":
                            XmlElementFactory(xe);
                            break;
                        case "ShowErrors":
                            XmlElementFactory(xe);
                            break;
                        case "BlockWords":
                            XmlElementFactory(xe);
                            break;
                        case "ApiKey":
                            XmlElementFactory(xe);
                            break;
                        case "SecretKey":
                            XmlElementFactory(xe);
                            break;
                        case "App_Id":
                            XmlElementFactory(xe);
                            break;
                        default:
                            break;
                    }
                }
                else
                    continue;

            }

            xmlDoc.Save(configPath);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private static void XmlElementFactory(XmlElement xe)
        {
            xe.SetAttribute("value", Encryption.Base64EnCode(xe.GetAttribute("value")));
        }
        
    }
}
