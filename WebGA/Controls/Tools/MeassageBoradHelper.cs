/**
 * 完成日期：2018-5-19
 * 描述：留言板
 * */
using System;
using System.Collections.Generic;
using Models;
using System.Text;
using System.Linq;
using System.Data;
using BasicTools;

namespace WebGA.Controls.Tools
{
    public class MeassageBoradHelper
    {
        public Paging<UserMessageBoard> paging = null;
        public List<UserMessageBoard> mbAll = null;
        public static List<MBCategories> mbCategories = null;

        public MeassageBoradHelper()
        {
            this.mbAll = UserMessageBoardService.listAllMB;
            this.paging = new Paging<UserMessageBoard>(mbAll, 10);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="eachCount">设置页面数据条数</param>
        public MeassageBoradHelper(int eachCount)
        {
            this.mbAll = UserMessageBoardService.listAllMB;
            this.paging = new Paging<UserMessageBoard>(mbAll, eachCount);
        }
        /// <summary>
        /// 获取当前页
        /// </summary>
        /// <returns></returns>
        public string GetMeassageBoradPage()
        {
            return GetMeassageBorad(paging.GetPage());
        }
        /// <summary>
        /// 获取下一页
        /// </summary>
        /// <returns></returns>
        public string GetNextPage()
        {
            return GetMeassageBorad(paging.NextPage());
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <returns></returns>
        public string GetProviousPage()
        {
            return GetMeassageBorad(paging.ProviousPage());
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <returns></returns>
        public string GetLastPage()
        {
            return GetMeassageBorad(paging.EndPage());
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <returns></returns>
        public string GetTopPage()
        {
            return GetMeassageBorad(paging.FirstPage());
        }
        /// <summary>
        /// 跳转到指定页
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetGotoPage(int index)
        {
            return GetMeassageBorad(paging.GotoPage(index));
        }
        /// <summary>
        /// 获取评论  分类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCategories()
        {
            return UserMessageBoardService.GetCategories();
        }
        /// <summary>
        /// 添加评论，返回状态值 -1(未输入文本或用户不存在!) ,1(发布失败!),0（发布成功）
        /// </summary>
        /// <param name="userId">用户唯一标识</param>
        /// <param name="title">标题</param>
        /// <param name="comment">文本内容</param>
        /// <param name="categoriesId">分类ID</param>
        /// <returns></returns>
        public static int PublishAnArticle(int userId,string title,string comment,int categoriesId)
        {
            if (comment.Length > 0 && userId > 0)
            {
                BlockWordsSerach bws = BlockWordsSerach.GetInstance();
                if (bws.IsBlockWord(comment))
                {
                    if (MeassageBoradInData(userId, title, bws.Replace(comment), categoriesId))
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    if (MeassageBoradInData(userId, title, comment, categoriesId))
                        return 0;
                    else
                        return 1;
                }
            }
            else
               return -1 ;
        }
        private static bool MeassageBoradInData(int userId,string title,string comment,int categoriesId)
        {
            return UserMessageBoardService.AddUserMessageBoard(userId, title, comment, UserMessageBoardManager.GET_DEFULT_URL, DateTime.Now, categoriesId);
        }


        /// <summary>
        /// 获取留言板分类信息
        /// </summary>
        /// <returns></returns>
        public static string GetMessageBoradCategories()
        {
            mbCategories = UserMessageBoard.MBCategories;
            string reult = string.Empty;
            if (mbCategories != null)
            {
                for (int i = 0; i < mbCategories.Count; i++)
                {
                    reult += WebPageControls.ListGroups(mbCategories[i].cetegoriesTitle, mbCategories[i].sum);
                    if (i == 4)
                        return reult;
                }
                return reult;
            }
            else
            {
                return reult;
            }
        }
        private static string GetMessageBoradCategories(List<MBCategories> dataSource)
        {
             string reult = string.Empty;
             if (dataSource != null)
             {
                 foreach (MBCategories i in dataSource)
                 {
                     reult += WebPageControls.ListGroups(i.cetegoriesTitle, i.sum);
                 }
                 return reult;

             }
             else
             {
                 reult += "数据错误!请尝试重新加载!";
                 return reult;
             }
        }
        /// <summary>
        /// 获取当前页的留言板
        /// </summary>
        /// <returns></returns>
        private static string GetMeassageBorad(List<UserMessageBoard> userMB)
        {
            if (userMB != null)
            {
                string reult = string.Empty;
                foreach (UserMessageBoard i in userMB)
                {
                    if (i != null)
                    {
                        string title = i.Title.Trim() != "" ? i.Title : "无标题";
                        string content = i.Article;  
                        string author = i.user != null ? (i.user.name.Trim() != "" ? i.user.name : "公众用户") : "公众用户";
                        string url = i.URL.Trim() != "" ? i.URL : "#";
                        DateTime comTime = i.ComDateTime;
                        string categoriesTitle = i.MessageBoardCategories.CategoriesTitle.Trim() != "" ? i.MessageBoardCategories.CategoriesTitle : "默认分类";

                        reult += WebPageControls.SimpMessageBoard(title, content, author, url, comTime,categoriesTitle);
                    }
                    else
                        reult +=  WebPageControls.ReminderBox("网络延迟!");
                }
                return reult;
            }
            else
                return WebPageControls.SimpMessageBoard("留言区为空!" , "系统信息", DateTime.Now,"");
        }
    }
}
