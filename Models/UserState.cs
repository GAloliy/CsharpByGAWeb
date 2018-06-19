using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public class UserState
    {
        private int _id;
        private string _name;
        public UserState()
        {

        }

        public int id
        {
            get { return this._id;}
            set{this._id = value;}
        }
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
