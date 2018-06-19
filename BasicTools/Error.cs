
/*
 *   自定义错误工具类
 * 摘要:一些常用枚举.
 * 完成日期:18-3-28
 * 作者:@GAloliy
 * 此类有待优化，准备实现高并发设计模式（暂时没有时间弄）
 */


using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

namespace BasicTools
{
    [Serializable]
    public sealed class Error : ApplicationException
    {
        private string m_id;
        private ErrorTypeEnum m_errorType;
        private string m_machineName;
        private DateTime m_errorTime;
        private string m_userID;
        private string m_visitPage;
        private string m_desc;
        private const string VISIPAGE_ERROR = "Http上下文为空,会话已结束!";

        //初始化
        private void Initialize()
        {

            m_id = System.Guid.NewGuid().ToString();
            m_errorType = ErrorTypeEnum.UnknownError;
            m_machineName = Environment.MachineName;
            m_errorTime = DateTime.Now;
            if (HttpContext.Current != null)
                m_visitPage = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + HttpContext.Current.Request.Path;
            else
                m_visitPage = VISIPAGE_ERROR;
            m_desc = "";
        }
        //初始化
        private void Initialize(string userID)
        {
            if (userID.Length > 0)
                m_userID = userID;
            m_id = System.Guid.NewGuid().ToString();
            m_errorType = ErrorTypeEnum.UnknownError;
            m_machineName = Environment.MachineName;
            m_errorTime = DateTime.Now;
            if(HttpContext.Current != null)
                m_visitPage = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + HttpContext.Current.Request.Path;
            else
                m_visitPage = VISIPAGE_ERROR;
            m_desc = "";
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="message">异常信息</param>
        public Error(string message)
            : base(message)
        {
            Initialize();
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="userID">导致异常的用户ID</param>
        /// <param name="message">异常信息</param>
        public Error(string userID, string message)
            : base(message)
        {
            Initialize(userID);
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="message">自定义异常信息</param>
        /// <param name="description">异常信详细描述息</param>
        /// <param name="innerException">引发此异常的异常对象</param>
        public Error(string message, string description, Exception innerException)
            : base(message, innerException)
        {
            Initialize();
            m_desc = description;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="userID">导致异常的用户ID</param>
        /// <param name="message">自定义异常信息</param>
        /// <param name="description">异常详细描述信息</param>
        /// <param name="innerException">引发此异常的异常对象</param>
        public Error(string userID, string message, string description, Exception innerException)
        {
            Initialize(userID);
            m_desc = description;
        }
        /// <summary>
        /// 异常ID
        /// </summary>
        public string ErrorID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        /// <summary>
        /// 异常类型
        /// </summary>
        public ErrorTypeEnum ErrorType
        {
            get { return m_errorType; }
            set { m_errorType = value; }
        }
        /// <summary>
        /// 异常所在机器名
        /// </summary>
        public string MachineName
        {
            get { return m_machineName; }
            set { m_machineName = value; }
        }
        /// <summary>
        /// 异常发生时间
        /// </summary>
        public DateTime ErrorTime
        {
            get { return m_errorTime; }
            set { m_errorTime = value; }
        }
        /// <summary>
        /// 引发异常的用户ID
        /// </summary>
        public string UserID
        {
            get { return m_userID; }
            set { m_userID = value; }
        }
        /// <summary>
        /// 引发异常的页面
        /// </summary>
        public string VisitPage
        {
            get { return m_visitPage; }
            set { m_visitPage = value; }
        }
        /// <summary>
        /// 自定义异常描述信息
        /// </summary>
        public string Description
        {
            get { return m_desc; }
            set { m_desc = value; }
        }
    }
}
