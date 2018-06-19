/*
 *  文件操作类
 * 摘要:文件的常用的操作
 * 完成日期:18-3-30
 * 作者:@GAloliy
 */

using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

namespace BasicTools
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public sealed class FileOperation
    {
        /// <summary>
        /// 文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static long FileSize(string filePath)
        {
            long temp = 0;
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string si in str1)
                {
                    temp += FileSize(si);
                }
            }
            else
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return filePath.Length;
            }
            return temp;
        }
        /// <summary>
        /// 是否有此文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static bool IsFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///写入文本，如果没有该文件则创建一个文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="LogString">正文</param>
        /// <returns></returns>
        public static string WritFile(string filePath, string LogString)
        {
            try
            {
                //true表示追加文件
                StreamWriter sw = new StreamWriter(filePath,true,Encoding.UTF8);
                sw.WriteLine(LogString);
                sw.Flush();
                sw.Close();
                return "写入成功！";
            }
            catch (Exception ex)
            {

                Error error = new Error("文件操作错误！","文件正在被占用！",ex);
                Log.WriteLog(error);
                return ex.Message.ToString();
            }
        }
       /// <summary>
       /// 获取文件的字符串形式
       /// </summary>
       /// <param name="filePath">路径</param>
       /// <returns></returns>
        public static string GetFileString(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs);

                byte[] file = br.ReadBytes((int)fs.Length);

                br.Close();
                fs.Close();

                Encoding encode = Encoding.UTF8;

                return encode.GetString(file);
            }
            catch (Exception ex)
            {

                Error err = new Error("获取文件错误！", "获取的文件路径不对或文件不存在！", ex);
                Log.WriteLog(err);

                //显示错误信息
                return null;
            }
        }
        /// <summary>
        /// 判断是否有此文件夹
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static bool IsDirectoryInfoExists(string filePath)
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);

            return dir.Exists;
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filePath">路径</param>
        public static void DirectoryInfoCreate(string filePath)
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);
            if(dir.Exists == false)
            dir.Create();
        }
        /// <summary>
        /// 将具有指定URI的文件下载到指定路径
        /// </summary>
        /// <param name="Uri">地址</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static string UriDownLoadFile(string Uri,string filePath)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            wc.DownloadFile(Uri,filePath);


            //将下载的内容以string形式返回
            Stream data = wc.OpenRead(Uri);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();

            data.Close();
            reader.Close();

            return s;
        }
        /// <summary>
        /// 获取文件大小(单位KB)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static long GetFileSize(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            return fileInfo.Length / 1024;
        }

        /*public class AsyncReadWrite
        {
            byte[] byDataIn;
            byte[] byDataOut;
            char[] charData;

            public AsyncReadWrite(String filePath)
            {
                
                byDataIn = new byte[100];
                charData = new Char[100];
                byDataOut = new byte[100];

                try
                {
                    //读取文件共享读写
                    FileStream sourceFile = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                   //写入文件共享读写
                    FileStream targetFile = new FileStream(filePath,FileMode.Open,FileAccess.Write,FileShare.ReadWrite);

                    AsyncCallback readCallBack = new AsyncCallback(this.HandleRead);

                    sourceFile.EndRead(readResult);
                   targetFile.EndWrite(writeResult);
                   sourceFile.Close();
                   targetFile.Close();
                }
                catch (Exception e)
                {
                    
                    throw;
                }
            }

            private void HandleRead(IAsyncResult ar)
            {
                //将已编码字节的序列转换为一组字符（Decoder）
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(byDataIn,0,byDataIn.Length,charData,0);

                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byDataOut, 0, true);
            }
            private void HandleWrite(IAsyncResult ar)
            {

            }
        }*/

        public class AsyncReadWrite
        {
            private static AsyncReadWrite instance = null;
            public static ThreadPoolStatus status = ThreadPoolStatus.Stop;
            public  FileData readData { get;private set; }
            private FileStream streamWrite = null;


            public class FileData
            {
                public FileStream Stream = null;
                public int Length = -1;
                public byte[] ByteData;
                /// <summary>
                /// 读取的数据,string格式
                /// </summary>
                public string StringData = string.Empty;
                public bool IsCompleted = false;
            }
   
            protected AsyncReadWrite()
            {}
            /// <summary>
            /// 获取实例AsyncReadWrite
            /// </summary> 
            /// <returns></returns>
            public static AsyncReadWrite GetInstance()
            {
                if (instance == null)
                {
                    ThreadPool.SetMaxThreads(Config.ThreadPoolSize,Config.ThreadPoolSize);        //设置线程池最大值
                    status = ThreadPoolStatus.Start;            //线程现状状态
                    instance = new AsyncReadWrite();
                    return instance;
                }
                else
                    return instance;
            }

            public void AsyncWrite(FileStream fileStream ,string textContent,Encoding coding)
            {
                streamWrite = fileStream;
                byte[] bytes = new byte[16384];
                bytes = coding.GetBytes(textContent);
                //Encoding.UTF8.GetBytes(textContent);

                //启动异步写入
                streamWrite.BeginWrite(bytes, 0, (int)bytes.Length, new AsyncCallback(CallbackWrite), streamWrite);
                streamWrite.Flush();
            }
            /// <summary>
            /// 异步写入文件如果没有该文件则创建文件并写入(UFT-8格式)
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="textContent"></param>
            public void AsyncWrite(string filePath, string textContent)
            {
                AsyncWrite(filePath,textContent,FileMode.OpenOrCreate,1024,Encoding.UTF8);
            }

            /// <summary>
            /// 异步写入文件 1024 buffer
            /// </summary>
            /// <param name="filePath">路径</param>
            /// <param name="textContent">要写入的文本</param>
            /// <param name="mode">模式</param>
            /// <param name="coding">编码</param>
            public void AsyncWrite(string filePath, string textContent, FileMode mode, Encoding coding)
            {
                AsyncWrite(filePath, textContent, mode, 1024, coding);
            }
            /// <summary>
            /// 异步写入文件
            /// </summary>
            /// <param name="filePath">文件路径</param>
            /// <param name="textContent">要写入的文本</param>
            /// <param name="mode">模式</param>
            /// <param name="buffer">缓存区</param>
            /// <param name="coding">编码格式</param>
            public void AsyncWrite(string filePath,string textContent,FileMode mode,int buffer,Encoding coding)
            {

                FileStream fileStreamWrite = new FileStream(filePath,mode, FileAccess.ReadWrite, FileShare.ReadWrite, buffer, true);
                AsyncWrite(fileStreamWrite,textContent,coding);
            }
            /// <summary>
            /// 写文件的回调函数
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            private void CallbackWrite(IAsyncResult result)
            {
                //线程池现状;这里的线程必须要休眠200毫秒.否则是出现文件已关闭错误情形
                Thread.Sleep(200);
                status = ThreadPoolStatus.CallbackWrite;

                //结束异步写入
                streamWrite = (FileStream)result.AsyncState;
                streamWrite.EndWrite(result);
                streamWrite.Close();
            }

            /// <summary>
            /// 异步读取最大77MB
            /// </summary>
            /// <param name="filePath"></param>
            public void AsyncRead(string filePath)
            {
                AsyncRead(filePath, FileMode.OpenOrCreate, 1024, 80961024);
            }
            /// <summary>
            /// 异步读取
            /// </summary>
            /// <param name="filePath">路径</param>
            /// <param name="mode">模式</param>
            public void AsyncRead(string filePath,FileMode mode)
            {
                AsyncRead(filePath,mode, 1024, 80961024);
            }
            /// <summary>
            /// 异步读取
            /// </summary>
            /// <param name="filePath">路径</param>
            /// <param name="mode">模式</param>
            /// <param name="buffer">缓冲区</param>
            /// <param name="byteSize">读取文件最大数</param>
            public void AsyncRead(string filePath,FileMode mode,int buffer,long byteSize)
            {
                byte[] byteData = new byte[byteSize];
                FileStream streamRead = new FileStream(filePath,mode,FileAccess.ReadWrite,FileShare.ReadWrite,buffer,true);
                /*
                 * 把FileStream对象,byte[]对象,
                 * 长度等有关数据绑定到FileData对象中
                 * 以附带属性方式送到回调函数
                 */
                if(readData == null)
                    readData = new FileData();

                readData.Stream = streamRead;
                readData.Length = (int)streamRead.Length;
                readData.ByteData = byteData;

                //启动异步读取
                streamRead.BeginRead(byteData, 0, readData.Length, new AsyncCallback(CallbackRead), readData);
            }
            /// <summary>
            /// 读取回调函数
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            private void CallbackRead(IAsyncResult result)
            {
                status = ThreadPoolStatus.CallbackRead;

                FileData fileData = (FileData)result.AsyncState;
                int length = fileData.Stream.EndRead(result);
                fileData.Stream.Close();
                //读取到的长度不一致
                if (length != fileData.Length)
                    Log.WriteLog(new Error(ThreadPoolMessage(),"读取流没有完成！(读取到的长度不一致)"));
                else
                {
                    string data = Encoding.UTF8.GetString(fileData.ByteData, 0, fileData.Length);
                    fileData.StringData = data;
                    readData = fileData;
                }
            }
            /// <summary>
            /// 返回线程池现状信息
            /// </summary>
            /// <param name="status"></param>
            public static string ThreadPoolMessage()
            {
                int workerThreads, completionPortThreads;

                ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                string message = string.Format("{0}\n 当前线程ID(CurrentTheradID)：{1}\n 工作中的线程(WorkerThreads)：{2}\n 完成端口线程(CompletionPortThreads):{3}", status.ToString(), Thread.CurrentThread.ManagedThreadId, workerThreads.ToString(), completionPortThreads.ToString());
              
                return message;
            }

            public enum ThreadPoolStatus
            {
                Stop,
                Start,
                CallbackWrite,
                CallbackRead,
                Error
            }

        }


        #region FTP操作
        //string FTPMessage = string.Empty;
        //NetworkCredential networkCredential;
        //Exception FtpException = null;

        ////创建FTP连接
        //private FtpWebRequest CreateFtpWebRequest(string uri,string requestMethod)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        //    request.Credentials = networkCredential;
        //    request.KeepAlive = true;
        //    request.UseBinary = true;
        //    request.Method = requestMethod;

        //    return request;
        //}

        ///// <summary>
        ///// 获取服务器状态信息
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public FtpWebResponse GetFtpWebResponse(FtpWebRequest request)
        //{
        //    FtpWebResponse response = null;
        //    try
        //    {
        //        response = (FtpWebResponse)request.GetResponse();
        //        FTPMessage = "验证完毕,服务器回应信息:[" + response.WelcomeMessage.ToString() + "]" + 
        //                    "</br>正在连接:[" + response.BannerMessage.ToString() + "]";
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}



        #endregion
    }
}
