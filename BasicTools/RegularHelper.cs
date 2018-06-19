
/*
 *  用户工具类
 * 摘要:一些常用的正则表达式.
 * 完成日期:18-3-27
 * 作者:@GAloliy
 */

using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BasicTools
{
    /// <summary>
    /// RegularHelper类 主要用来用户注册的一些验证，比如邮箱地址，手机号码等等。
    /// </summary>
    public static class RegularHelper
    {
     //   MatchCollection mc = Regex.Matches("","");

        /// <summary>
        /// 电话号码
        /// </summary>
        /// <param name="str_telephone"></param>
        /// <returns></returns>
        public static bool IsTelephone(string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool IsHandset(string str_handset)
        {
            return Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <param name="str_idcard"></param>
        /// <returns></returns>
        public static bool IsIDcard(string str_idcard)
        {
            return Regex.IsMatch(str_idcard,@"(^\d{18}$)|(^\d{15}$)");
        }
        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="str_number"></param>
        /// <returns></returns>
        public static bool IsNumber(string str_number)
        {
            return  Regex.IsMatch(str_number,@"^[0-9]*$");
        }
        /// <summary>
        /// 邮编
        /// </summary>
        /// <param name="str_postalcode"></param>
        /// <returns></returns>
        public static bool IsPostalcode(string str_postalcode)
        {
            return Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
        /// <summary>
        /// 帐号是否合法(字母开头，允许5-16字节，允许字母数字下划线)
        /// </summary>
        /// <param name="str_user"></param>
        /// <returns></returns>
        public static bool IsUserNumber(string str_user)
        {
            return Regex.IsMatch(str_user, @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$");
        }
        /// <summary>
        /// 密码(以字母开头，长度在6~18之间，只能包含字母、数字和下划线)
        /// </summary>
        /// <returns></returns>
        public static bool IsPasswordNumber(string str_password)
        {
            return Regex.IsMatch(str_password, @"^[a-zA-Z]\w{5,17}$");
        }
        /// <summary>
        /// 是否是ip地址
        /// </summary>
        /// <param name="str_ipaddress"></param>
        /// <returns></returns>
        public static bool IsIPaddress(string str_ipaddress)
        {
            return Regex.IsMatch(str_ipaddress, @"\d+\.\d+\.\d+\.\d+");
        }
        /// <summary>
        /// 获取字符串中的字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetLetter(string str)
        {
            Regex r = new Regex(@"[a-zA-Z]+");

            return r.Match(str).Value;
        }
        /// <summary>
        /// 从字符串中获取数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetNumber(string str)
        {
            int result = 0;
            if (str != null && str.Length > 0)
            {
                str = Regex.Replace(str, @"[^\d.\d]", "");
                if (Regex.IsMatch(str,@"^[+-]?\d*[.]?\d*$"))
                {
                    result = int.Parse(str);   
                }
            }

            return result;
        }
        /// <summary>
        /// 自定义正则
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regularStr"></param>
        /// <returns></returns>
        public static bool isRegular(string str,string regularStr)
        {
            Regex r = new Regex(regularStr);
            return r.IsMatch(str);
        }
    }
}
