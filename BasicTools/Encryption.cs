
/*
 * 加密工具类
 * MD5，BASE64
 */
using System;
using System.Text;
using System.Security.Cryptography;

namespace BasicTools
{
    /// <summary>
    /// 加密类
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// MD5加密,返回密文
        /// </summary>
        /// <param name="input">要加密的内容</param>
        /// <returns></returns>
        public static string GetMd5Hash(string source)
        {
            //新建哈希实例
            MD5 md5Hash = MD5.Create();
            // 将输入字符串转换为字节数组并计算哈希。
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));

            //创建一个新的StringBuilder来收集字节并创建字符串
            StringBuilder sBuilder = new StringBuilder();

            //循环遍历哈希数据的每个字节，并将每个字节格式化为十六进制字符串
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            //返回十六进制字符串。
            return sBuilder.ToString();

        }
        /// <summary>
        /// 验证MD5是否相同(不区分大小写)
        /// </summary>
        /// <param name="input">密文</param>
        /// <param name="hash">要验证的密文</param>
        /// <returns></returns>
        public static bool VerifyMd5Hash(string sourceHash, string hash)
        {
            //不区分大小写
            StringComparer sComparer = StringComparer.OrdinalIgnoreCase;

            if (0 == sComparer.Compare(sourceHash, hash))
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        private static readonly object cbeOb = new object();
        /// <summary>
        /// 加密Base64^
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CustomEnBase64(string source)
        {
            lock (cbeOb)
            {
                string encode = string.Empty;
                const char keys = '8';
                const string ePwassword = "jlGla";
                StringBuilder sBuilder = new StringBuilder(source);
                byte[] bytes = null;

                if (source.Length > 0)
                {
                    sBuilder.Append(ePwassword);

                    bytes = Encoding.UTF8.GetBytes(sBuilder.ToString());

                    encode = CustomExclusiceOrEncrytion(bytes,keys);
                    
                }
                return encode;
            }
        }

        private static readonly object cdbOb = new object();
        /// <summary>
        /// 解密Base64^
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string CustomDeBase64(string ciphertext)
        {
            lock (cdbOb)
            {
                string decode = string.Empty;
                const char keys = '8';
                StringBuilder sb = new StringBuilder(ciphertext);
                byte[] bytes = null;

                if (ciphertext.Length > 0)
                {
                    sb.Remove(ciphertext.Length - 5, 5);
                    bytes = Encoding.UTF8.GetBytes(sb.ToString());

                    decode = CustomExclusiceOrEncrytion(bytes, keys);
                }
                return decode;   
            }
        }

        /// <summary>
        /// ^加解密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CustomExclusiceOrEncrytion(string source)
        {
            const char keys = '7';
            return CustomExclusiceOrEncrytion(Encoding.UTF8.GetBytes(source), keys);
        }

        private static readonly object ceoeOb = new object();
        public static string CustomExclusiceOrEncrytion(byte[] bytes,char keys)
        {
            lock (ceoeOb)
            {
                if (bytes.Length > 0)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = (byte)(bytes[i] ^ keys);
                    }
                }
                return Encoding.UTF8.GetString(bytes);   
            }
        }

        /// <summary>
        /// Base64加密,UTF8加密
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public static string Base64EnCode(string source)
        {
            return Base64EnCode(Encoding.UTF8,source);
        }
        /// <summary>
        /// Base64加密实现
        /// </summary>
        /// <param name="encodeType">加密类型</param>
        /// <param name="source">明文</param>
        /// <returns></returns>
        private static string Base64EnCode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            const string ePwassword = "lp";
            const string ePwassword1 = "Galklci";
            StringBuilder sBuilder = new StringBuilder(source);
            byte[] bytes = null;

            try
            {
                if (source.Length > 0)
                {
                    //第一次加密
                    sBuilder.Append(ePwassword);

                    bytes = encodeType.GetBytes(sBuilder.ToString());
                    encode = Convert.ToBase64String(bytes);

                    //第二次加密
                    sBuilder = new StringBuilder(encode);
                    sBuilder.Insert(0, ePwassword1);

                    bytes = encodeType.GetBytes(sBuilder.ToString());
                    encode = Convert.ToBase64String(bytes);

                }
                return encode;
            }
            catch (Exception ex)
            {
                encode = source;
                Error err = new Error("加密错误","明文为空或其他未知错误",ex);
                Log.WriteLog(err);
                return null;
            }
        }
        /// <summary>
        ///  Base64解密 UTF8
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string Base64DeCode(string result)
        {
            return Base64DeCode(Encoding.UTF8, result);
        }
        /// <summary>
        /// Base64解密实现
        /// </summary>
        /// <param name="encodeType">编码方式</param>
        /// <param name="result">密文</param>
        /// <returns></returns>
        private static string Base64DeCode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            StringBuilder sBuilder = null;
            byte[] bytes = null;

            try
            {
                if (result.Length > 0)
                {
                    //解密1
                    bytes = Convert.FromBase64String(result);
                    decode = encodeType.GetString(bytes);

                    sBuilder = new StringBuilder(decode);
                    sBuilder.Remove(0, 7);

                    //解密2
                    bytes = Convert.FromBase64String(sBuilder.ToString());
                    decode = encodeType.GetString(bytes);

                    sBuilder = new StringBuilder(decode);
                    sBuilder.Remove((sBuilder.Length - 2), 2);
                }
                return sBuilder.ToString();
            }
            catch (Exception ex)
            {
                Error err = new Error("加密错误","密文为空或其他未知情况",ex);
                Log.WriteLog(err);

                return null;
            }
        }
    }
}
