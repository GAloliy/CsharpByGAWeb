using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using BasicTools;
using Models;

namespace WebGA
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           // string ec = Config.EncryptionConfig;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Log.WriteLog(new Error("未知程序错误!"));
            }
            catch (Exception ex)
            { }

        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                User user = Session["CurrentUser"] as User;
                if (user != null)
                {
                    UserManager.ModifyUserStatusById(user.id);
                }
            }
            catch (Exception ex)
            {

                Log.WriteLog(new Error("修改用户信息错误！", "Session_End发生错误", ex));
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}