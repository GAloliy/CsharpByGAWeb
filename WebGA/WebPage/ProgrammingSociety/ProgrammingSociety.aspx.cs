using System;
using System.Web;
using System.Text;
using BasicTools;

namespace WebGA.WebPage.ProgrammingSociety
{
    public partial class ProgrammingSociety : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定事件
            submit.ServerClick += new EventHandler(submit_ServerClick);
        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            string actualName = name.Value;
            string introduction = profession.Value;
            string comtactInformation = contactin.Value;
            string contact = contactMessage.Value;

            if (actualName.Length == 0 || introduction.Length == 0 || contact.Length == 0)
            {
                Response.Write("<script>alert('姓名,专业和联系方式不能为空，请重新填写')</script>");
            }
            else
            {
                try
                {
                    string path = HttpContext.Current.Server.MapPath(@"/Subscription/Contact.txt");
                    string lc = "\r\n";
                    StringBuilder sBuilder = new StringBuilder("============================================" + lc);
                    sBuilder.Append("姓名：" + actualName + lc);
                    sBuilder.Append("专业：" + introduction + lc);
                    sBuilder.Append("联系方式：" + comtactInformation + lc);

                    if (contact.Length > 0)
                        sBuilder.Append("简介：" + contact + lc);


                    FileOperation.AsyncReadWrite writeContact = FileOperation.AsyncReadWrite.GetInstance();

                    writeContact.AsyncWrite(path, sBuilder.ToString());
                    //FileOperation.WritFile(path, sBuilder.ToString());

                    Response.Write("<script>alert('提交成功！')</script>");
                }
                catch (Exception ex)
                {

                    Error err = new Error("提交‘联系我们’表单出错！","未知错误！",ex);
                    Log.WriteLog(err);
                }

            }
        }
    }
}
