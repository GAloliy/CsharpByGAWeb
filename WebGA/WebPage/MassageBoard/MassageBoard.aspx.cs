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
using WebGA.Controls.Tools;

namespace WebGA.WebPage.MassageBoard
{
    public partial class MassageBoard : System.Web.UI.Page
    {
        private static User user = null;
        private static MeassageBoradHelper mbh;
        private static int index = -1;
        private static bool isParse = false;
        private static int indexPage = 1;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnPublish.ServerClick += new EventHandler(btnPublish_ServerClick);                //留言发表
            this.pagingbtnGotoPage.ServerClick += new EventHandler(pagingbtnGotoPage_ServerClick);  //跳转按钮
            this.pagingFistPage.ServerClick += new EventHandler(pagingFistPage_ServerClick);        //首页链接
            this.pagingLastPage.ServerClick += new EventHandler(pagingLastPage_ServerClick);        //最后一页链接
            this.pagingNextPage.ServerClick += new EventHandler(pagingNextPage_ServerClick);        //下一页链接
            this.pagingProviousPage.ServerClick += new EventHandler(pagingProviousPage_ServerClick);//上一页链接
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["CurrentUser"] as User;
            mbh = new MeassageBoradHelper();

            if (!IsPostBack)
            {
                this.MBcategories.Items.Clear();
                this.MBcategories.DataSource = MeassageBoradHelper.GetCategories();
                this.MBcategories.DataTextField = "CategoriesTitle";
                this.MBcategories.DataValueField = "CategoriesId";
                this.MBcategories.DataBind();
            }

            GetPageIndex();
            this.pagingAllPage.InnerHtml = "一共有" + mbh.paging.AllPage.ToString() + "页数据";
            divMassageBorad.InnerHtml = mbh.GetTopPage();
             ulMBCategories.InnerHtml =  MeassageBoradHelper.GetMessageBoradCategories();

             if (user != null)
                 if (user.name.Length > 0)
                     this.userName.InnerHtml = user.name;
        }

        //留言发表
        protected void btnPublish_ServerClick(object sender, EventArgs e)
        {
            string comment = this.txtComment.Value.Trim();
            string title = this.txtTitile.Value.Trim();

            if (user == null)
            {
                this.spPublishReult.InnerHtml = "<a style=\"color:red; \">请登录后尝试! </a>";
            }
            else
            {
                string str = string.Empty;
                bool isRePost = false;
                switch (MeassageBoradHelper.PublishAnArticle(user.id,title,comment,int.Parse(this.MBcategories.SelectedValue)))
                {
                    case 0:
                        str = "<a>发布成功!</a>";
                        isRePost = true;
                        break;
                    case 1:
                        str = "<a>发布失败!请重新再试!</a>";
                        break;
	                default:
                        str = "<a style=\"color:Red\">请输入内容!</a>";
                     break;
                }
                if (isRePost)
                {
                    Response.Redirect("MassageBoard.aspx");
                }else
                    this.spPublishReult.InnerHtml = str;
                
            }
        }

        private void GetPageIndex()
        {
            this.pagingIndexPage.InnerHtml = "当前在第" + mbh.paging.IndexPage.ToString() + "页";
        }

        protected void pagingProviousPage_ServerClick(object sender, EventArgs e)
        {
            divMassageBorad.InnerHtml = mbh.GetProviousPage();
            GetPageIndex();
        }

        protected void pagingNextPage_ServerClick(object sender, EventArgs e)
        {
            divMassageBorad.InnerHtml = mbh.GetNextPage();
            GetPageIndex();
        }

        protected void pagingLastPage_ServerClick(object sender, EventArgs e)
        {
            divMassageBorad.InnerHtml = mbh.GetLastPage();
            GetPageIndex();
        }

        protected void pagingFistPage_ServerClick(object sender, EventArgs e)
        {
            divMassageBorad.InnerHtml = mbh.GetTopPage();
            GetPageIndex();
        }

        protected void pagingbtnGotoPage_ServerClick(object sender, EventArgs e)
        {
            isParse = int.TryParse(this.pagingGotoPage.Value.Trim(),out index);
            if(isParse)
                divMassageBorad.InnerHtml = mbh.GetGotoPage(index);
            else
                divMassageBorad.InnerHtml = "跳转失败!请检查您输入的是否为数字!";
            GetPageIndex();
        }
    }
}
