/*
 * 
 * Date : 2018-6-3
 * LastModified:6-3 1:04
 * AuthorName : @GAloliy
 * 
 * */

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
using System.Text;
using Models;
using WebGA.Controls.Tools;

namespace WebGA.WebPage.UploadFile
{
    public partial class CommentManagement : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            User user = Session["CurrentUser"] as User;
            if (user == null || !user.userRole.name.Equals("Admin"))
                Response.Redirect("../Main.aspx");

            base.OnInit(e);
            pagingProviousPage.ServerClick += new EventHandler(pagingProviousPage_ServerClick);
            pagingbtnGotoPage.ServerClick += new EventHandler(pagingbtnGotoPage_ServerClick);
            pagingFistPage.ServerClick += new EventHandler(pagingFistPage_ServerClick);
            pagingLastPage.ServerClick += new EventHandler(pagingLastPage_ServerClick);
            pagingNextPage.ServerClick += new EventHandler(pagingNextPage_ServerClick);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            tc = new WebPageControls.TableControls(contentDT, SIZE_PAGE, AJAX_URL);
            GetViewBind(tc.GotoPage(1));
            if (!IsPostBack)
            {
                categroies.DataSource = UserMessageBoardService.GetCategories();
                categroies.DataTextField = "CategoriesTitle";
                categroies.DataValueField = "CategoriesId";
                categroies.DataBind();
            }
            GetPageIndex();
            pagingAllPage.InnerHtml = "一共有" + tc.TotalPage.ToString() + "页";
        }

        private void GetPageIndex()
        {
            pagingIndexPage.InnerHtml = "当前页" + tc.pageIndex.ToString();
        }

        private const int SIZE_PAGE = 10;
        private static DataTable dt = null;
        private const string AJAX_URL = "../UploadFile/CommentManagement.aspx/GetMemberId";
        protected static DataTable contentDT
        {
            get
            {
                dt = UserMessageBoardService.GetMessageBoardIn();
                return dt;
            }
        }
        static WebPageControls.TableControls tc;

        protected static string MemberID;

        [System.Web.Services.WebMethod()]
        public static int ModifyInfo(string sources)
        {
            string[] src = sources.Split('；');
            string MBId   =      src[0];
            var title     =      src[1];
            var content   =      src[2];
            var linkURL   =      src[3];
            int categroie = int.Parse(src[4]);

            return UserMessageBoardService.ModifyBaseInfo(MBId,title,content,linkURL,categroie);
        }

        [System.Web.Services.WebMethod()]
        public static int DelElement(string id)
        {
            return UserMessageBoardService.DeleteMessageBoardByID(id);
        }

        [System.Web.Services.WebMethod()]
        public static string GetMemberId(string id)
        {
            string selectText = "MessageBoardId = '" + id + "'";
            MemberID = id;
            const string i = ",";
            DataRow rw = tc.SelectDataById(selectText);

            var MBId = rw[0].ToString();
            var author = rw[1].ToString();
            var title = rw[2].ToString();
            var content = rw[3].ToString();
            var linkURL = rw[4].ToString();
            var categroies = rw[6].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append(MBId + i);
            sb.Append(author + i);
            sb.Append(title + i);
            sb.Append(content + i);
            sb.Append(linkURL + i);
            sb.Append(categroies + i);

            return sb.ToString();
        }

        void pagingbtnGotoPage_ServerClick(object sender, EventArgs e)
        {
            int pageIndex = 1;
            if (int.TryParse(pagingGotoPage.Value.Trim(),out pageIndex))
            {
                if (pageIndex <= 0)
                {
                    pageIndex = 1;
                }
                else if (pageIndex >= tc.TotalPage)
                {
                    pageIndex = tc.TotalPage;
                }
                GetViewBind(tc.GotoPage(pageIndex));
                GetPageIndex();
            }
            else
            {
                Response.Write("<script>alert(' 请输入正确的页码! ')</script>");
            }
        }

        void pagingNextPage_ServerClick(object sender, EventArgs e)
        {
            GetViewBind(tc.NextPage());
            GetPageIndex();
        }

        void pagingLastPage_ServerClick(object sender, EventArgs e)
        {
            GetViewBind(tc.GotoPage(tc.pageRows.Length));
            GetPageIndex();
        }

        void pagingFistPage_ServerClick(object sender, EventArgs e)
        {
            GetViewBind(tc.GotoPage(1));
            GetPageIndex();
        }

        void pagingProviousPage_ServerClick(object sender, EventArgs e)
        {
            GetViewBind(tc.ProviousPage());
            GetPageIndex();
        }

        protected void GetViewBind(string source)
        {
            tbody.InnerHtml = source;
        }
        /*
        protected void gvCM_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetViewBind();
        }

        protected void gvCM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <=0; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='pink'");


                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
        }

        protected void gvCM_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GetViewBind();
        }

        protected void gvCM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = dt.Rows[e.RowIndex][0].ToString();
            int result = UserMessageBoardService.DeleteMessageBoardByID(id);

            if (result > 0)
            {
                GetViewBind();

                Response.Write("<script>alert('删除成功!')</script>");
            }

            GetViewBind();
        }

        protected void gvCM_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GetViewBind();
        }

        protected void gvCM_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           // int result = UserMessageBoardService.UpdataMessageBoardByDataTable(dt);
            string indexName = "gvCM$ctl0" + (e.RowIndex + 2).ToString().Trim();

            int rowIndex = e.RowIndex;

            string id = dt.Rows[rowIndex][0].ToString();
            //string name = Request.Form[(indexName + "$ctl03")].ToString();
            string title = Request.Form[(indexName + "$ctl04")].ToString();
            string article = Request.Form[(indexName + "$ctl05")].ToString();
            string url = Request.Form[(indexName + "$ctl06")].ToString();
           // string comtime = Request.Form[(indexName + "$ctl07")].ToString();
            string categoriesTitle = Request.Form[(indexName + "$ctl08")].ToString();

            //int result = UserMessageBoardService.UpdataMessageBoardByDataTable(id,title,article,url,categoriesTitle);

            Response.Write("<script>alert('编辑"  + "成功!')</script>");
            GetViewBind();
        } */
    }
         
}
