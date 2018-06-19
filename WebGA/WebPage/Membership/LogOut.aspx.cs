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

namespace WebGA.WebPage.Membership
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if ((User)(Session["CurrentUser"]) != null)
            {
                Session.Abandon();
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                Response.Redirect("../Main.aspx");
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
