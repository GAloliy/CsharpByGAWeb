using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Models;

namespace WebGA.WebPage.Template
{
    public partial class MenuBarRelativePath : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.homePost.ServerClick += new EventHandler(homePost_ServerClick);
            zhux.ServerClick += new EventHandler(zhux_ServerClick);
        }

        void homePost_ServerClick(object sender, EventArgs e)
        {
            User user = Session["CurrentUser"] as User;
            if (user != null)
            {
                if (user.userRole.id == 2)
                {
                    Response.Redirect("../UploadFile/UploadFile.aspx");
                }
                else
                    Response.Redirect("../Main.aspx");

            }
            else
            {
                Response.Redirect("../Main.aspx");
            }
        }

        protected void zhux_ServerClick(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                Session.Abandon();
                Response.Write("<script>alert('注销成功!')</script>");
                Response.Redirect("../Main.aspx");
            }
            else
                Response.Write("<script>alert('您没有登陆!请登录后注销(滑稽)')</script>");
        }
    }
}