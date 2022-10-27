using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared.Commom
{
    public class PageResult<T>
    {

        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalItems { get; set; }


        /// <summary>
        /// 数据集
        /// </summary>
        public List<T> Items { get; set; }
    }
}
