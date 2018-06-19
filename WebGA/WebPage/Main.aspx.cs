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
using BasicTools;
using Models;
using System.IO;
using WebGA.Controls.Tools;
using System.Collections.Generic;
using System.Linq;

namespace WebGA.WebPage
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            User user = Session["CurrentUser"] as User;

                if (user != null)
                {
                    /*
                    List<UserMessageBoard> umb = user.UserMessageBoard;

                    if(umb != null)
                    if (umb.Count >= 1)
                    {
                        //var board = umb.OrderBy(x => x.MessageBoardId).ThenByDescending(x => x.ComDateTime).Select(x => x);
                        //from x in umb orderby x.ComDateTime ascending select x;

                        foreach (var item in umb)
                        {
                            divtest.InnerHtml += WebPageControls.SimpMessageBoard(item.Title, item.Article, user.name + "橡树" +umb.Count, item.URL, item.ComDateTime,item.MessageBoardCategories.CategoriesTitle);
                        }
                    }*/
                }
        }
    }
}