using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class MBCategories
    {
        public string cetegoriesTitle { get; set; }
        public int cetegoriesId { get; set; }
        public int sum { get; set; }
    }
    public class MessageBoardCategories
    {
        private int _categoriesId = -1;
        private string _categoriesTitle = string.Empty;

        public MessageBoardCategories(int categoriesId, string categoriesTitle)
        {
            this._categoriesId = categoriesId;
            this._categoriesTitle = categoriesTitle;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoriesId
        {
            get
            {
                return _categoriesId;
            }
            set
            {
                this._categoriesId = value;
            }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoriesTitle
        {
            get
            {
                return this._categoriesTitle;
            }
            set
            {
                this._categoriesTitle = value;
            }
        }
    }
}
