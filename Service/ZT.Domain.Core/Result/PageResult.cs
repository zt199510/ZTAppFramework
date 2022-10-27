using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Core.Result
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/7 14:05:56 
    /// Description   ：  
    ///********************************************/
    /// </summary>
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
