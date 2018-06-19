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
    public partial class PersonalInfo : System.Web.UI.Page
    {
        private static User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["CurrentUser"] as User;

            if (user == null)
                Response.Redirect("UserLogin.aspx");
            else
            {
                btnModifyInfo.ServerClick += new EventHandler(modifyInfo_ServerClick);
                btnSavePwd.ServerClick += new EventHandler(btnSavePwd_ServerClick);

                txtName.Attributes["placeholder"] = user.name;
                txtPhone.Attributes["placeholder"] = user.phone;
                txtMail.Attributes["placeholder"] = user.mail;
                txtAddress.Attributes["placeholder"] = user.address;
                signature.Attributes["placeholder"] = user.PerSonalSynopsis;
                
            }
        }

        protected void btnSavePwd_ServerClick(object sender, EventArgs e)
        {
            if (Verification())
            {
                Response.Write("<script>alert('修改成功,请重新登录！');</script>");
                relut.InnerHtml = "<font color='red'>修改成功,请重新登录！</font>";
                Session.Abandon();
                Response.Redirect("../Main.aspx");
            }
        }

        public bool Verification()
        {
            string pldPwd = oldPassword.Value.Trim();
            string modifyPwd = nodifyNewPassword.Value.Trim();
            string reModifyPwd = reNodifyNewPassword.Value.Trim();

            if (pldPwd.Length > 0 && modifyPwd .Length> 0 && reModifyPwd.Length > 0)
            {
                if (modifyPwd.Equals(reModifyPwd))
                    if (pldPwd.Equals(user.loginPwd))
                    {
                        if (UserManager.ModifyUser(user.id, modifyPwd))
                        {
                            return true;
                        }
                        else
                        {
                            relut.InnerHtml = "<font color='red'>密码修改失败！</font>";
                            return false;
                        }
                    }
                    else
                    {
                        relut.InnerHtml = "<font color='red'>原密码不正确！</font>";
                        oldPassword.Focus();
                        return false;
                    }
                else
                {
                    relut.InnerHtml = "<font color='red'>新密码与原密码不同！</font>";
                    return false;
                }
            }
            else
            {
                relut.InnerHtml = "<font color='red'>请确定您已经填完修改密码的需要的所有内容！</font>";
                return false;
            }
        }

        public bool VerficationBaseInfo()
        {
            string strName = txtName.Value.Trim().Length <= 0 ? user.name:txtName.Value.Trim();
            string strAddress = txtAddress.Value.Trim().Length <= 0 ? user.address : txtAddress.Value.Trim();
            string strPhone = txtPhone.Value.Trim().Length <= 0 ? user.phone : txtPhone.Value.Trim();
            string strPer = signature.Value.Trim().Length <= 0 ? user.PerSonalSynopsis : signature.Value.Trim();
            string strMali = txtMail.Value.Trim().Length <= 0 ? user.mail : txtMail.Value.Trim();

            if (strName.Length > 0 && strAddress.Length > 0 && strPhone.Length > 0 && strPer.Length > 0 && strMali.Length > 0)
            {
                user = UserService.ModifyBaseInfo(user.id, strAddress, strPhone, strPer, strMali, strName);
                if (user != null)
                {
                    Session["CurrentUser"] = user;
                    return true;
                }
                else
                {
                    user = Session["CurrentUser"] as User;
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('基本信息不能为空!')</script>");
                return false;
            }
        }
        protected void modifyInfo_ServerClick(object sender, EventArgs e)
        {
            if (VerficationBaseInfo())
            {
                Response.Write("<script>alert('修改成功!')</script>");
                Response.Redirect("PersonalInfo.aspx");
            }
        }

        protected string GetUserInfo(UserInfo userInfo)
        {
            if(user != null)
                switch (userInfo)
                {
                    case UserInfo.name:
                         return user.name;
                    case UserInfo.loginId:
                        return user.loginId;
                    case  UserInfo.address:
                        return user.address;
                    case UserInfo.phone:
                        return user.phone;
                    case UserInfo.LastOnlineTime:
                        return user.LastOnlineTime.ToString();
                    case UserInfo.mail:
                        return user.mail.ToString();
                    case UserInfo.perSonalSynopsis:
                        return user.PerSonalSynopsis;
                    case UserInfo.role:
                        return user.userRole.name;
                    default:
                        return "错误！";
                }
            else
                switch (userInfo)
                {
                    case UserInfo.name:
                        return "名字";
                    case UserInfo.loginId:
                        return "登录ID";
                    case UserInfo.address:
                        return "地址";
                    case UserInfo.phone:
                        return "手机号码";
                    case UserInfo.LastOnlineTime:
                        return "最后登录时间";
                    case UserInfo.mail:
                        return "邮箱";
                    case UserInfo.perSonalSynopsis:
                        return "没有写简介哦";
                    default:
                        return "错误!";
                }
        }
        public enum UserInfo
        {
            name,
            loginId,
            address,
            phone,
            LastOnlineTime,
            mail,
            perSonalSynopsis,
            role

        }
        protected string GetImageURI()
        {
            Random random = new Random();
            int i = random.Next(4);
            return "Resources/image/" + i.ToString() + ".jpg";
        }
    }
}
