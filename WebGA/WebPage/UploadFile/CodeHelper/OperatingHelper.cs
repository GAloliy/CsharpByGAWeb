using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BasicTools;

namespace UploadFile.CodeHelper
{
    public sealed class OperatingHelper
    {
        private static TreeView pageTV;
        private static HttpContext webContext = HttpContext.Current;

        /// <summary>
        /// 在浏览器上显示一个提示框
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="msg">消息</param>
        public static void MsgAlert(Page page,string msg)
        {
            string scriptString = string.Format("alert('{0}')",msg);
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), Guid.NewGuid().ToString("N"), scriptString, true);
        }
        /// <summary>
        /// 在浏览器上显示一个提示框
        /// </summary>
        /// <param name="msg">消息</param>
        public static void MsgAlert(string msg)
        {
            string script = string.Format("<script language = 'javascript'> alert('{0}')</script>",msg);
            HttpContext.Current.Response.Write(script);
        }
        public static void DelFile(TreeNode checkedTN)
        {
            File.Delete(checkedTN.Value);
            checkedTN.Parent.ChildNodes.Remove(checkedTN);
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static TreeNode CreateFolder(string path,string folderName)
        {

            TreeNode treeNode = new TreeNode(); 
            string folderPath = path + "/" + folderName;
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            dirInfo.Create();
            treeNode.Text = folderName;
            treeNode.Value = dirInfo.FullName;
            treeNode.ShowCheckBox = false;

            return treeNode;
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void DelFolder(string path)
        {
            Directory.Delete(path);
        }
        #region 获取文件节点操作
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pageTreeView"></param>
        public static TreeNode Initiallzation(string path)
        {
            try
            {
                if (path != null && path.Length > 0)
                {
                    string dirPath = webContext.Server.MapPath("~/" + path);
                    DirectoryInfo dir = new DirectoryInfo(dirPath);
                    if (dir.Exists == false) dir.Create();
                    //创建带有指定文本的节点实例（对象）
                    TreeNode treeNode = new TreeNode(dir.FullName);
                    //设置节点的值
                    treeNode.Value = dir.FullName;
                    treeNode.ShowCheckBox = false;
                    //获取文件夹节点
                    GetDirTreeNode(treeNode, dir);
                    //返回节点
                    return treeNode;
                }
                return null;
            }
            catch (Exception e)
            {
                Error err = new Error("初始化出错！", "请检查OperatingHelper.Initiallzation", e);
                Log.WriteLog(err);
                return null;
            }
            finally
            {
                if (pageTV != null)
                    pageTV = null;
            }
        }
        //递归获取文件夹下所有节点
        private static void GetDirTreeNode(TreeNode treeNode, DirectoryInfo dir)
        {
            if (dir.Exists)
            {
                foreach (DirectoryInfo dirIndex in dir.GetDirectories())
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dirIndex.Name;
                    newTreeNode.Value = dirIndex.FullName;
                    //添加节点
                    treeNode.ChildNodes.Add(newTreeNode);
                    newTreeNode.ShowCheckBox = false;
                    //递归
                    GetDirTreeNode(newTreeNode,dirIndex);
                }

                treeNode.ShowCheckBox = false;
                GetFilesTreeNode(treeNode,dir);

            }
        }
        //获取文件节点
        private static void GetFilesTreeNode(TreeNode treeNode, DirectoryInfo dir)
        {
            foreach (FileInfo fileIndex in dir.GetFiles())
            {
                string loadPath = webContext.Server.MapPath("~/");
                string filePath = fileIndex.FullName.Replace(loadPath, "");
                filePath = "~/" + filePath.Replace("\\", "/");

                TreeNode newTreeNode = new TreeNode(fileIndex.Name);
                newTreeNode.Value = fileIndex.FullName;
                //设置目标窗口或框架
                newTreeNode.Target = "iframeUI";
                newTreeNode.NavigateUrl = filePath;
                //添加节点
                treeNode.ChildNodes.Add(newTreeNode);
            }
        }
        #endregion
    }
}
