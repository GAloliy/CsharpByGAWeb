/*
 * Date : 2018-6-3
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
using System.Collections.Specialized;

namespace WebGA.WebPage.UploadFile
{
    public partial class MembershipManagement : System.Web.UI.Page
    {
        private static DataTable dt = null;
        protected static DataTable contentDT{
            get{
                dt = UserService.GetAllUsersInfo();
               return dt;
            }
        }
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
        private const int SIZE_PAGE = 10;
        private const string AJAX_URL = "../UploadFile/MembershipManagement.aspx/GetMemberId";
        private static WebPageControls.TableControls tc;
        private static int memberId;
        public static int MemberId
        {
            get { return memberId; }
        }

        [System.Web.Services.WebMethod()]
        public static int ModifyInfo(string sources)
        {
            string[] src = sources.Split('；');
            int userId = int.Parse(src[0]);
            string name = src[1];
            string signature = src[2];
            string mail = src[3];
            string phone = src[4];
            string address = src[5];
            int role = int.Parse(src[6]);



            return UserManager.ModifyBasicInfo(userId,address,phone,signature,mail,name,role);
        }

        [System.Web.Services.WebMethod()]
        public static int DelElement(int id)
        {
            return UserService.DelUserById(id);
        }

        [System.Web.Services.WebMethod()]
        public static string GetMemberId(int id)
        {
            string selectText = "Id = '" + id +"'";
            memberId = id;
            DataRow rw = tc.SelectDataById(selectText);
            string userId = rw[0].ToString();
            string loginId = rw[1].ToString();
            string name = rw[2].ToString();
            string address = rw[3].ToString();
            string phone = rw[4].ToString();
            string mail = rw[5].ToString();
            string role = rw[6].ToString();
            string personalSynopsis = rw[9].ToString();
            string i = ",";

            StringBuilder sb = new StringBuilder();
            sb.Append(userId + i);
            sb.Append(loginId + i);
            sb.Append(name + i);
            sb.Append(address + i);
            sb.Append(phone + i);
            sb.Append(mail + i);
            sb.Append(role + i);
            sb.Append(personalSynopsis);


            return sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tc = new WebPageControls.TableControls(contentDT, SIZE_PAGE, AJAX_URL);
            GetViewBind(tc.GotoPage(1));

            if (!IsPostBack)
            {
                role.DataSource = UserRoleService.GetRoles();
                role.DataTextField = "Name";
                role.DataValueField = "Id";
                role.DataBind();
            }
            GetPageIndex();
            pagingAllPage.InnerHtml = "一共有" + tc.TotalPage.ToString() + "页";
        }
        private void GetPageIndex()
        {
            pagingIndexPage.InnerHtml = "当前页" + tc.pageIndex.ToString();
        }
        public void GetViewBind(string source)
        {
              tbody.InnerHtml = source; 
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

        void pagingbtnGotoPage_ServerClick(object sender, EventArgs e)
        {
            int pageIndex = 1;
            if (int.TryParse(pagingGotoPage.Value.Trim(), out pageIndex))
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
                Response.Write("<script>alert(' 请输入正确的页码! ')</script>");
        }

        void pagingProviousPage_ServerClick(object sender, EventArgs e)
        {
            GetViewBind(tc.ProviousPage());
        }
    }
}
