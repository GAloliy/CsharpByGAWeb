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
using BasicTools;
using Models;
//using BLL;

namespace WebGA
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string fromUrl = "";  //用户访问的前一个网页的地址 TODO:未加密
        protected void Page_Load(object sender, EventArgs e)
        {
            //fromUrl = Request.Form[""];
            if (!IsPostBack)
            {
                if (Session["CurrentUser"] != null)
                {
                    Response.Write("<script>var isCon = confirm('当前已登录,您是否需要切换用户?');if(isCon) window.location.replace('LogOut.aspx'); else window.location.replace('../Main.aspx');</script>");
                   // Response.Redirect("PersonalInfo.aspx");
                }
                
            }
        }
        //登录
        protected void Login_Click(object sender, EventArgs e)
        {
            User user;
            string txUser = this.tbuser.Text.Trim();
            string txPassword = this.tbpassword.Text.Trim();

            //TODO:加密步骤

            if (UserManager.Login(txUser, txPassword, out user))
            {
                Session["CurrentUser"] = user;
                const int STATECODE_ONLINE = 2;
                UserManager.ModifyUserStatusById(user.id, STATECODE_ONLINE);
                user.userState = UserManager.GetUserStateById(user.id);

                if (fromUrl.Length > 0)
                {
                    Response.Redirect(fromUrl);
                }
                else
                {
                    Response.Redirect("PersonalInfo.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码不正确，请重新填写')</script>");
            }
        }
        //注册
        protected void Zhuc_Click(object sender, EventArgs e)
        {
            string user = tb1user.Text;
            string pwd = tb1password.Text;
            string repwd = tb1repassword.Text;
            string email = tbemail.Text;
            const string defaultUser = "公众用户";

            if (user.Length > 0 && pwd.Length > 0 && repwd.Length > 0 && email.Length > 0)
            {
                User newUser = new User();
                newUser.loginId = user;
                newUser.loginPwd = Encryption.CustomExclusiceOrEncrytion(pwd);
                newUser.mail = email;
                newUser.address = "中国";
                newUser.phone = "0";
                newUser.name = defaultUser;

                bool isReult = UserManager.Register(newUser);
                if (isReult)
                    Response.Write("<script>alert('注册成功!')</script>");
                else
                    Response.Write("<script>alert('已有该用户！')</script>");
            }
            else
            {
                Response.Write("<script>alert('不能为空！')</script>");
            }
        }
    }
}
