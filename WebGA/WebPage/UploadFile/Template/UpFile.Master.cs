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
using UploadFile.CodeHelper;
using BasicTools;
using System.Web.Services;

namespace WebGA.WebPage.UploadFile.Template
{
    public partial class UpFile1 : System.Web.UI.MasterPage
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnDelFile.ServerClick += new EventHandler(btnDelFile_ServerClick);
            btnDelFolder.ServerClick += new EventHandler(btnDelFolder_ServerClick);
            btnUploadFile.ServerClick += new EventHandler(btnUploadFile_ServerClick);
            btnCreateFolder.ServerClick += new EventHandler(btnCreateFolder_ServerClick);
            btnDownloadPSFile.ServerClick += new EventHandler(btnDownloadPSFile_ServerClick);
            btnDownloadProLog.ServerClick += new EventHandler(btnDownloadProLog_ServerClick);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.iframeUI.Attributes.Add("src", "https://www.baidu.com/");

            //Server.CreateObject("Microsoft.XMLDOM");
        }

        void btnDownloadProLog_ServerClick(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Subscription/";
            const string FILE_NAME = "Log.txt";
            string file = path + FILE_NAME;
            DownloadFile(file, FILE_NAME);
        }

        void btnDownloadPSFile_ServerClick(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Subscription/";
            const string FILE_NAME = "Contact.txt";
            string file = path + FILE_NAME;
            DownloadFile(file,FILE_NAME);
        }

        private void DownloadFile(string filePath,string fileName)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
                {
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();

                    Response.ContentType = "application/octect-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                OperatingHelper.MsgAlert(this.Page, "暂时没有该资源!");
            }
        }

        TreeNode tn = null;
        TreeNode getTreeNode {get { return this.treeViewMain.SelectedNode; } }

        [WebMethod]
        public static string asynUploadFile()
        {
            return "Fuck";
        }
        //上传文件
        void btnUploadFile_ServerClick(object sender, EventArgs e)
        {

            tn = getTreeNode;

            if (tn == null || tn.Value.Split('.').Length > 1)
            {
                OperatingHelper.MsgAlert(this.Page, "请选择你要上传的文件夹!");
            }
            else
            {
                if (fileUpLoad.HasFile)
                {
                    HttpFileCollection files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile postedFile = files[i];
                        if (postedFile.ContentLength > 0)
                        {

                            string fileName = postedFile.FileName;//处理文件名
                            fileName = DateTime.Now.Ticks.ToString() + fileName;


                            //Server.MapPath(@"FileSpace\" + fileName);
                            string strPath = tn.Value + @"\" + fileName;

                            try
                            {
                                postedFile.SaveAs(strPath);

                                OperatingHelper.MsgAlert(this.Page, postedFile.FileName + "上传成功");
                                Response.Redirect("UploadFile.aspx");
                            }
                            catch (HttpException ex)
                            {
                                OperatingHelper.MsgAlert(this.Page, "请求文件上传失败,请过一会再试!");
                            }

                        }
                        else
                            OperatingHelper.MsgAlert(this.Page, "没有文件!");
                    }
                }
            }
        }
        //删除文件夹
        void btnDelFolder_ServerClick(object sender, EventArgs e)
        {
                
            tn = getTreeNode;

            if ( tn == null || tn.Value.Split('.').Length > 1)
            {
                OperatingHelper.MsgAlert(this.Page,"请选择你要删除的文件夹!");
            }
            else
            {
                try
                {
                    OperatingHelper.DelFolder(tn.Value);
                    tn.Parent.ChildNodes.Remove(tn);
                    OperatingHelper.MsgAlert(this.Page, "文件夹删除成功(如不能正常显示请刷新网页)");
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //OperatingHelper.MsgAlert(this.Page, "该文件夹已删除");
                    Response.Redirect("UploadFile.aspx");
                }
                catch (System.IO.IOException ioex)
                {
                    OperatingHelper.MsgAlert(this.Page, "删除失败,请确认您删除的文件夹里没有子文件夹.");
                }
            }
        }

        //删除文件
        void btnDelFile_ServerClick(object sender, EventArgs e)
        {
            TreeView treeView = this.treeViewMain;
            int checkedCount = treeView.CheckedNodes.Count;

            if (checkedCount > 0)
            {
                for (int i = checkedCount -1; i > -1; i--)
                {
                    tn = treeView.CheckedNodes[i];
                    OperatingHelper.DelFile(tn);
                }
            }
            else
            {
                OperatingHelper.MsgAlert(this.Page,"请选择要删除的文件！");
            }
        }
        //创建文件夹
        void btnCreateFolder_ServerClick(object sender, EventArgs e)
        {
            tn = getTreeNode;
            string folderName = this.txtFolderName.Value;
            string regular = "(?!((^(con)$)|^(con)/..*|(^(prn)$)|^(prn)/..*|(^(aux)$)|^(aux)/..*|(^(nul)$)|^(nul)/..*|(^(com)[1-9]$)|^(com)[1-9]/..*|(^(lpt)[1-9]$)|^(lpt)[1-9]/..*)|^/s+|.*/s$)(^[^/////:/*/?/\"/</>/|]{1,255}$)";

            if (folderName.Length > 0 || tn != null)
            {
                if (RegularHelper.isRegular(folderName, regular))
                {
                    string folderPath = tn.Value + "/" + folderName;
                    if (FileOperation.IsDirectoryInfoExists(folderPath))
                    {
                        //OperatingHelper.MsgAlert(this.Page, "已存在该文件夹！");
                        Response.Redirect("UploadFile.aspx");
                    }
                    else
                        tn.ChildNodes.Add(OperatingHelper.CreateFolder(tn.Value, folderName));
                }
                else
                    OperatingHelper.MsgAlert(this.Page,"文件夹名不能为空或有特殊符号！");
            }
            else
                OperatingHelper.MsgAlert(this.Page,"未选中节点或未输入文件夹名！");
        }
        //初始化
        public void InitTreeNode(string path)
        {
            
            TreeNode treeNode = OperatingHelper.Initiallzation(path);
            if(treeNode != null)
            this.treeViewMain.Nodes.Add(treeNode);
        }
    }
}
