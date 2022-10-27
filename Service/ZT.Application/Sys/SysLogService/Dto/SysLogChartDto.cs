using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/10/12 10:39:16 
    /// Description   ：  15日 图表
    ///********************************************/
    /// </summary>
    public class SysLogChartDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public List<string> Time { get; set; } = new();

        /// <summary>
        /// 数量
        /// </summary>
        public List<List<int>> Count { get; set; } = new();
    }
}
