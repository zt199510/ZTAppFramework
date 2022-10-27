using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Core.Param
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 11:13:08 
    /// Description   ： 分页参数 
    ///********************************************/
    /// </summary>
    public class PageParam : CommonParam
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每页多少条
        /// </summary>
        public int Limit { get; set; } = 10;

    }

    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParam<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每页多少条
        /// </summary>
        public int Limit { get; set; } = 15;

        /// <summary>
        /// 查询条件
        /// </summary>
        public T Filter { get; set; }
    }
}
