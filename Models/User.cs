
/*
 * User类是用户实体模型,直接抽象数据库表.
 * 
 *          不可随意改动User类变量属性名!!!
 *          
 * 并发性有待改进
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
   
    [Serializable()]
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User
    {
        private int _id = -1;                          //用户编号
        private UserRole _userRole;                 //角色外键对象
        private UserState _userState;               //状态外键对象
        private string _address = string.Empty;     //联系地址
        private string _loginId = string.Empty;     //账号
        protected string _loginPwd = string.Empty;    //密码
        private string _mail = string.Empty;        //邮箱
        private string _name = string.Empty;        //姓名
        private string _phone = string.Empty;       //手机号码
        private DateTime _LastOnlineTime;
        private string _personalSynopsis = string.Empty;
        private List<UserMessageBoard> _userMessageMoard = null;

        public User()
        {

        }
        /// <summary>
        /// 角色外键对象
        /// </summary>
        public UserRole userRole
        {
            get { return this._userRole; }
            set{this._userRole = value;}
        }
        /// <summary>
        /// 状态外键对象
        /// </summary>
        public UserState userState
        {
            get { return this._userState; }
            set{this._userState = value;}
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string address
        {
            get{return this._address; }
            set{this._address = value;}
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string loginId
        {
            get { return this._loginId; }
            set { this._loginId = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string loginPwd
        {
            get { return this._loginPwd; }
            set { this._loginPwd = value; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string mail
        {
            get { return this._mail; }
            set { this._mail = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastOnlineTime
        {
            get { return _LastOnlineTime; }
            set { _LastOnlineTime = value; }
        }
        /// <summary>
        /// 用户个性签名(简介)
        /// </summary>
        public string PerSonalSynopsis
        {
            get { return this._personalSynopsis; }
            set { this._personalSynopsis = value; }
        }
        /// <summary>
        /// 用户留言板
        /// </summary>
        public List<UserMessageBoard> UserMessageBoard
        {
            get { return this._userMessageMoard; }
            set { this._userMessageMoard = value; }
        }
    }
}
