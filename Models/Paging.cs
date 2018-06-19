using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Paging<T>
    {
        public List<T> DataSource = new List<T>();
        public int IndexPage { get; set; }
        public int AllPage { get; set; }
        public int EachCount { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="eachCount">一页中显示几条数据</param>
        public Paging(List<T> dataSource,int eachCount) {
            this.DataSource = dataSource;
            this.AllPage = (int)Math.Ceiling((double)this.DataSource.Count / eachCount);
            this.EachCount = eachCount;
            this.IndexPage = 1;
        }
        /// <summary>
        /// 获取当前页
        /// </summary>
        /// <returns></returns>
        public List<T> GetPage()
        {
            return DataSource.Skip((IndexPage - 1) * EachCount).Take(EachCount).ToList();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <returns></returns>
        public List<T> NextPage()
        {
            IndexPage++;
            if (IndexPage > AllPage)
                IndexPage--;

            return GetPage();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <returns></returns>
        public List<T> ProviousPage()
        {
            IndexPage--;
            if (IndexPage == 0)
                IndexPage++;
            return GetPage();
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <returns></returns>
        public List<T> FirstPage()
        {
            this.IndexPage = 1;
            return GetPage();
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <returns></returns>
        public List<T> EndPage()
        {
            this.IndexPage = this.AllPage;
            return GetPage();
        }
        /// <summary>
        /// 跳转到指定页
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<T> GotoPage(int index)
        {
            if (index <= 0)
                this.IndexPage = 1;
            if (index >= AllPage)
                this.IndexPage = this.AllPage;

            this.IndexPage = index;
            return GetPage();
        }
    }
}
