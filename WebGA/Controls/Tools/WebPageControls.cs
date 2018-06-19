using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace WebGA.Controls.Tools
{
    public static class WebPageControls
    {
        public class TableControls
        {
            public DataRow[] pageRows;
            public int TotalPage;
            public int pageIndex;
            public string sourcePage;
            public string ajaxURL = "";
            private static int pageSize;
            private static StringBuilder sb;
            private static DataTable source;

            public TableControls(DataTable sourceDT,int pageSizeP,string url)
            {

                ajaxURL = url;
                pageSize = pageSizeP;
                source = sourceDT;
                pageRows = GetPageTable();
                sourcePage = GetTable(pageRows);
                TotalPage = GetTotalPage(source.Rows.Count);
                pageIndex = 1;
            }

            /// <summary>
            /// 上一页
            /// </summary>
            /// <returns></returns>
            public string ProviousPage()
            {
                pageIndex--;
                if (pageIndex <= 0)
                {
                    pageIndex = 1;
                }
                return GetTable(GetPageTable());
            }
            /// <summary>
            /// 下一页
            /// </summary>
            /// <returns></returns>
            public string NextPage()
            {
                pageIndex++;
                if (pageIndex >= TotalPage)
                {
                    pageIndex = TotalPage;
                }
                return GetTable(GetPageTable());
            }
            /// <summary>
            /// 跳转
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public string GotoPage(int index)
            {
                if (index >= TotalPage)
                    pageIndex = TotalPage;
             
                if(index <= 0)
                    pageIndex = 1;

                return GetTable(GetPageTable());
            }
            /// <summary>
            /// 返回分页后总页数
            /// </summary>
            /// <param name="totalPage">总记录</param>
            /// <param name="pageSize">每页条数</param>
            /// <returns></returns>
            public int GetTotalPage(int sumPage)
            {
                return (sumPage / pageSize) + (sumPage % pageSize > 0 ? 1 : 0);
            }
            public DataRow[] GetPageTable()
            {
                var rows = source.Rows.Cast<DataRow>();
                var curRows = rows.Skip(pageIndex).Take(pageSize).ToArray();
                return curRows;
            }
            public DataRow SelectDataById(string selectText)
            {
                return source.Select(selectText)[0];
            }
            public string GetTable(DataRow[] rows)
            {
                sb = new StringBuilder();

                int index = 0;
                const string ID_NAME = "edit";
                foreach (var item in rows)
                {
                    sb.Append("<tr runat='server'>");
                    for (int i = 0; i < source.Columns.Count; i++)
                    {
                        sb.Append("<th>");
                        sb.Append(item[i].ToString());
                        sb.Append("</th>");
                    }

                    sb.Append("<th runat='server'>");
                    sb.Append("<button type='button' onclick=\"postId('" + (item[0].ToString() + "," + ajaxURL).Trim() + "')\" class='btn-info' title=\" " + item[0].ToString().Trim() + " \" id=\"" + (ID_NAME + index.ToString()).Trim() + "\" name=\"" + (ID_NAME + index.ToString()).Trim() + "\" runat=\"server\" data-toggle=\"modal\" data-target=\"#myModal\" > Modify </button>");
                    sb.Append("</th>");

                    sb.Append("</tr>");
                    index++;
                }
                return sb.ToString();
            }
        }
        
        /// <summary>
        /// 简单的评论留言框（无标题无链接）
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="author">作者</param>
        /// <param name="comTime">发表时间</param>
        /// <returns></returns>
        public static string SimpMessageBoard(string content, string author, DateTime comTime,string categoriesTitle)
        {
            return SimpMessageBoard(content," ",author,"#",comTime,categoriesTitle);
        }
        /// <summary>
        /// 简单的评论留言框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="author">作者</param>
        /// <param name="url">链接</param>
        /// <param name="comTime">发表时间</param>
        /// <returns></returns>
        public static string SimpMessageBoard(string title,string content,string author,string url,DateTime comTime,string categoriesTitle)
        {
            StringBuilder sb = new StringBuilder("<a class=\"list-group-item list-group-item-action flex-column align-items-start\" href=");
            sb.Append("\" " + url + " \">");
            sb.Append("<div class=\"d-flex w-100 justify-content-between\"><h5 class=\"mb-1\">" + title + "</h5>");
            sb.Append("<small class=\"text-muted\">" + GetTimeSpan(comTime) + "</small>");
            sb.Append("</div><p class=\"mb-1\">" + content + "</p><small class=\"text-muted\">[分类]:" + categoriesTitle + " [作者]: " + author + " </small></a>");

            return sb.ToString();
        }

        /// <summary>
        /// 无链接警告提示框
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ReminderBox(string content)
        {
            return ReminderBox(content,"#"," ",ReminderBoxStatus.warning);
        }

        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="URL">链接</param>
        /// <param name="URLContent">链接内容</param>
        /// <param name="rbs">提示框状态（颜色）</param>
        /// <returns></returns>
        public static string ReminderBox(string content, string URL,string URLContent,ReminderBoxStatus rbs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"alert\" alert-dimissible alert-"  + rbs + " \">");
            sb.Append("<button class=\"close\" type=\"button\" data-dismiss=\"alert\">&times;</button>");
            sb.Append("<strong> ").Append(content).Append("</strong> <a class=\"alert-link\" href= \"").Append(URL + "\">").Append(URLContent + "</a></div>");

            return sb.ToString();
        }

        /// <summary>
        /// 白色列表组(配合简单工厂使用)
        /// </summary>
        /// <returns></returns>
        public static string ListGroups(string content,int sum)
        {
            StringBuilder sb = new StringBuilder("<li class=\"list-group-item d-flex justify-content-between align-items-center\">");
            sb.Append(content);
            
            sb.Append("<span class=\"badge badge-primary badge-pill\">");
            sb.Append(sum.ToString());
            sb.Append("</span>");
            sb.Append("</li>");
            return sb.ToString();
        }
        /// <summary>
        /// 黑色标题白色内容列表组（配合简单工厂使用）
        /// </summary>
        /// <returns></returns>
        public static string ListGroups(string titleUrl,string titleText,string addContent)
        {
            StringBuilder sb = new StringBuilder(" <div class=\"list-group\">");
            sb.Append("<a class=\"list-group-item list-group-item-action active\" href=\" " + titleUrl + " \">");
            sb.Append(titleText);
            sb.Append("</a>");

            sb.Append(addContent);

            sb.Append("</div>");
            return sb.ToString();
        }
        /// <summary>
        /// 简单工厂
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="content">内容</param>
        /// <param name="isDisabled">是否禁用链接</param>
        /// <returns></returns>
        public static string GetListGroupsFactory(string url, string content,bool isDisabled)
        {
            StringBuilder sb = new StringBuilder();
            string status = isDisabled ? "disabled" : " ";
            sb.Append("<a class=\"list-group-item list-group-item-action "  + status + "\" href=\" " + url + "\">");
            sb.Append(content);
            sb.Append("</a>");
            return sb.ToString();
        }
        /// <summary>
        /// 提示框状态颜色
        /// </summary>
        public enum ReminderBoxStatus
        {
            /// <summary>
            /// 危险
            /// </summary>
            danger,
            /// <summary>
            /// 警告
            /// </summary>
            warning,
            /// <summary>
            /// 成功
            /// </summary>
            success,
            /// <summary>
            /// 信息
            /// </summary>
            info,
            /// <summary>
            /// 默认主题(灰色)
            /// </summary>
            primary
        }


        private static string GetTimeSpan(DateTime comTime)
        {
            string reult = string.Empty;
            DateTime nowDT = DateTime.Now;
            if (comTime != null)
            {
                TimeSpan ts = nowDT.Subtract(comTime);
                long ticks = ts.Ticks / 10000000;

                if (ticks <= 60)
                {
                    return "1 分钟 前";
                }
                else if (ticks > 60 && ticks < 3600)
                {
                    return ts.Minutes.ToString() + "分钟 前";
                }
                else if (ticks > 3600 && ticks < 86400)
                {
                    return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟 前";
                }
                else if (ticks >= 86400 && ticks <= 31536000)
                {
                    return ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时 前";
                }
                else
                    return "已经过了很久了";
            }
            return "已经过了很久了";
        }
    }
}
