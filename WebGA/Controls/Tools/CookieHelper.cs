using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebGA.Tools
{
    public class CookieHelper
    {
        /// <summary>
        /// 清楚指定cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
        }
        /// <summary>
        /// 获取指定cookie值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            string cookieValue = string.Empty;
            if (cookie != null)
            {
                cookieValue = cookie.Value;
            }
            return cookieValue;
        }
        /// <summary>
        /// 添加一个cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieValue">值</param>
        /// <param name="expires">过期时间DATETIME</param>
        public static void AddCookie(string cookieName, string cookieValue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Expires  = expires,
                Value = cookieValue
            };
            HttpContext.Current.Response.Cookies.Add(cookie);

        }
    }
}
