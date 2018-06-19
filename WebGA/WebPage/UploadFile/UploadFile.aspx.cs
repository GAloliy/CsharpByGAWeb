using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Models;
using WebGA.WebPage.UploadFile.Template;

namespace WebGA.WebPage.UploadFile
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            User user = Session["CurrentUser"] as User;
            if (user == null || !user.userRole.name.Equals("Admin"))
                 Response.Redirect("../Main.aspx");
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            Master.InitTreeNode(@"WebPage\UploadFile\FileSpace");
        }
    }
}
