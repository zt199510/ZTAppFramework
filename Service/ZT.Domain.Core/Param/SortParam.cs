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
    /// 创建时间    ：  2022/9/8 11:15:37 
    /// Description   ：  上下移动参数
    ///********************************************/
    /// </summary>
    public class SortParam
    {
        /// <summary>
        /// 当前ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public long Parent { get; set; }

        /// <summary>
        /// 排序方式 0=向上  1=向下
        /// </summary>
        public int Type { get; set; }
    }
}
