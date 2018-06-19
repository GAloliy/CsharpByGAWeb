
/*
 * 日志信息
 */


using System;
using System.IO;
using System.Text;
using BasicTools;

namespace BasicTools
{
    public sealed class Log
    {

        private static readonly object padlock = new object();
        private static string logSizeIndex = RegularHelper.GetLetter(Config.LogMaxSize);
        private static long logSize = RegularHelper.GetNumber(Config.LogMaxSize);
        private static  string filePath = Config.LogFile;
        private static FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 3072, true);


        public static void WriteLog(Error err)
        {
            if (Config.LogEnabled == true)
            {
                if (err != null)
                    WriteFileLog(err);
            }
        }
        private static void WriteFileLog(Error err)
        {
            long fileSize = FileOperation.FileSize(filePath);

            switch (logSizeIndex)
            {
                case "B":
                    logSize = logSize / 1024;
                    break;
                case "M":
                    logSize = logSize * 1024;
                    break;
                case "G":
                    logSize = logSize * 1048576;
                    break;
                default:
                    break;
            }

            try
            {
                if (fileSize >= logSize)
                {
                    FileStream fileWrite = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

                    byte[] bytes = new byte[16384];
                    bytes = Encoding.UTF8.GetBytes(GetErrorString(err));
                    fileWrite.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(WriteCallback), fileWrite);
                    fileWrite.Flush();
                }
                else
                {
                    lock (padlock )
                    {
                        FileOperation.AsyncReadWrite fileWrite = FileOperation.AsyncReadWrite.GetInstance();
                        fileWrite.AsyncWrite(fileStream, GetErrorString(err) + "/n/r大小" + fileSize + "最大" + logSize, Encoding.UTF8);
                    }
                }
            }
            catch (Exception ex)
            {}
        }

        private static void WriteCallback(IAsyncResult result)
        {
            FileStream fileWrite = (FileStream)result.AsyncState;
            fileWrite.EndWrite(result);
            fileWrite.Close();
        }

        private static string GetErrorString(Error err)
        {
            string lc = "\r\n";
            StringBuilder sb = new StringBuilder();

            sb.Append("==============================================" + lc);
            sb.Append("发生错误,具体如下：" + lc);
            sb.Append("错误 ID:" + err.ErrorID + lc);
            sb.Append("发送时间:" + err.ErrorTime + lc);
            sb.Append("机器名称:" + err.MachineName + lc);
            sb.Append("错误信息：" + err.Message + lc);

            if(err.GetBaseException().TargetSite != null)
                sb.Append("所在方法：" + err.GetBaseException().TargetSite.Name + lc);

            if (err.UserID != null)
                sb.Append("用 户 ID：" + err.UserID + lc);

            sb.Append("访问页面：" + err.VisitPage + lc);
            sb.Append("堆栈信息：" + err.GetBaseException().StackTrace + lc);
            sb.Append(lc);

            return sb.ToString();
        }
    }
}
