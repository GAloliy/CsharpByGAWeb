using System;
using Models;
using System.Web;
using System.Web.UI;
using BasicTools;


namespace WebGA.Controls.Tools
{
    public sealed class WebPageHelper
    {
        private const string SESSION_NAME = "UserCurrent";
        private static bool m_isPermisson = true;
        /// <summary>
        /// 是否有权限
        /// </summary>
        public static bool IsPermission
        {
            get { return m_isPermisson; }
            set
            {
                m_isPermisson = value;
                HttpContext context = HttpContext.Current;
                //检测是否有权限
                if (value == false)
                {
                    context.Response.Write("<HTML><HEAD><TITLE>错误</TITLE></HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=big5\">");
                    context.Response.Write("<BODY>");
                    context.Response.Write("<P><B>对不起,您没有足够的权限!</B></p>");
                    context.Response.Write("</BODY>");
                    context.Response.End();
                }
            }

        }
        /// <summary>
        /// 用户是否登录
        /// </summary>
        public static bool IsLogin
        {
            get
            {
                return HttpContext.Current.Session[SESSION_NAME] != null;
            }
        }
        /// <summary>
        /// 获取会话对象
        /// </summary>
        /// <returns></returns>
        public static User GetCurrentSession()
        {
            User result = (User)HttpContext.Current.Session[SESSION_NAME];
            return result;
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="url">注销后转到的画面</param>
        public static void LogOut(string url)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
            context.Response.Write("<script language='javascript'>top.open('" + url + "', '_self');</script>");
            context.Response.End();
        }
        /// <summary>
        /// 获取当前Web应用程序的绝对路径 例/ http://localhost:58491/
        /// </summary>
        /// <returns></returns>
        public static string GetAppPath()
        {
            string result = string.Empty;

            HttpContext context = HttpContext.Current;
            Uri uri = context.Request.Url;

            if (uri.IsDefaultPort)
            {
                result += "http://" + uri.Host;
            }
            else
            {
                result += "http://" + uri.Host + ":" + uri.Port.ToString();
            }
            result += context.Request.ApplicationPath;
            return result;
        }
        /// <summary>
        /// 获取访问当前页面 例/http://localhost:58491/web/User/Login.aspx
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentPage()
        {
            return "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + HttpContext.Current.Request.Path;
        }
        /// <summary>
        /// 异常前端反馈信息处理
        /// </summary>
        public void OnError()
        {
            try
            {
                HttpContext context = HttpContext.Current;
                Exception ex = (Exception)context.Server.GetLastError();
                Error err = ex as Error;

                if (err == null)
                {
                    err = new Error(ex.Message, "发现未知异常！", ex)
                    {
                        ErrorType = ErrorTypeEnum.UnknownError
                    };
                }

                if (err.ErrorType == ErrorTypeEnum.BusinessError)
                {
                    context.Response.Write("<HTML><HEAD><TITLE>错误</TITLE></HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=big5\">");
                    context.Response.Write("<BODY>");
                    context.Response.Write("<P><B>信息提示:</B></P>");
                    context.Response.Write("</BOY>");
                    context.Response.End();
                }
                else
                {
                    if (Config.ShowErrors == true)
                    {
                        context.Response.Write("<HTML><HEAD><TITLE>错误</TITLE></HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=big5\">");
                        context.Response.Write("<BODY>");
                        context.Response.Write("<P><B>发生错误，具体如下：</B></P>");
                        context.Response.Write("错 误 ID：&nbsp;&nbsp;" + err.ErrorID + "<BR>");
                        context.Response.Write("发生时间：&nbsp;&nbsp;" + err.ErrorTime + "<BR>");
                        context.Response.Write("机器名称：&nbsp;&nbsp;" + err.MachineName + "<BR>");
                        context.Response.Write("错误信息：&nbsp;&nbsp;" + err.Message + "<BR>");
                        context.Response.Write("详细信息：&nbsp;&nbsp;" + err.Description + "<BR>");
                        context.Response.Write("错误来源：&nbsp;&nbsp;" + err.GetBaseException().Source + "<BR>");
                        context.Response.Write("所在方法：&nbsp;&nbsp;" + err.GetBaseException().TargetSite.Name + "<BR>");
                        context.Response.Write("用 户 ID：&nbsp;&nbsp;" + err.UserID + "<BR>");
                        context.Response.Write("访问页面：&nbsp;&nbsp;" + err.VisitPage + "<BR>");
                        context.Response.Write("堆栈信息：&nbsp;&nbsp;" + err.GetBaseException().StackTrace + "<BR>");
                        context.Response.Write("</BODY>");
                        context.Response.End();
                    }
                    else
                    {
                        // 只显示友好信息
                        context.Response.Write("<HTML><HEAD><TITLE>错误</TITLE></HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=big5\">");
                        context.Response.Write("<BODY>");
                        context.Response.Write("<P><B>发生错误，请记录：</B></P>");
                        context.Response.Write("错 误 ID：&nbsp;&nbsp;" + err.ErrorID + "<BR><BR>");
                        context.Response.Write("请将错误ID发送给您的管理员以解决问题，谢谢合作。<BR>");
                        context.Response.Write("</BODY>");
                        context.Response.End();
                    }
                }
            }
            catch { }
        }
    }
}
