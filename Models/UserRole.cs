/**
 * 实体角色
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable()]
    public class UserRole
    {
        private int _id;
        private string _name;

        public UserRole()
        {

        }
        /// <summary>
        /// 角色编号
        /// </summary>
        public int id
        {
            get{return this._id;}
            set{this._id = value;}
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string name
        {
            get { return this._name;}
            set{this._name = value;}
        }
    }
}
