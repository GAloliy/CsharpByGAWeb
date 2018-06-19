using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class UserMessageBoard
    {
        private Guid messageBoradId;
        private string title = string.Empty;
        private string article = string.Empty;
        private string url = string.Empty;
        private DateTime comDateTime;
        public User user = null;
        private MessageBoardCategories messageBoardCategories = null;
        public static List<MBCategories> mbCategories = null;

        public UserMessageBoard()
        {}
        /// <summary>
        /// 带参数初始化
        /// </summary>
        /// <param name="_messageBoard">唯一标识码</param>
        /// <param name="_title">标题</param>
        /// <param name="_article">内容</param>
        /// <param name="_url">链接</param>
        /// <param name="_comDateTime">发表时间</param>
        /// <param name="_messageBoardCategories">留言分类</param>
        public UserMessageBoard(Guid _messageBoard, string _title, string _article, string _url, DateTime _comDateTime)
        {
            this.messageBoradId = _messageBoard;
            this.title = _title;
            this.article = _article;
            this.url = _url;
            this.comDateTime = _comDateTime;
        }
        /// <summary>
        /// 留言板总数
        /// </summary>
        public static List<MBCategories> MBCategories
        {
            get
            {
                return mbCategories;
            }
            set
            {
                mbCategories = value;
            }
        }
        /// <summary>
        /// 留言板分类
        /// </summary>
        public MessageBoardCategories MessageBoardCategories
        {
            get
            {
                return this.messageBoardCategories;
            }
            set
            {
                this.messageBoardCategories = value;
            }
        }
        /// <summary>
        /// 留言板标识码
        /// </summary>
        public Guid MessageBoardId
        {
            get { return this.messageBoradId; }
            private set { this.messageBoradId = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Article
        {
            get { return this.article; }
            set { this.article = value; }
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string URL
        {
            get { return this.url; }
            set { this.url = value; }
        }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime ComDateTime
        {
            get { return this.comDateTime; }
            private set { this.comDateTime = value; }
        }
    }
}
