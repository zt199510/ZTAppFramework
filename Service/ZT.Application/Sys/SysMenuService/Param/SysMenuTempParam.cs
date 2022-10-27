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
    /// 创建时间    ：  2022/9/8 11:48:54 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysMenuTempParam
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public long ParentId { get; set; } = 0;
    }
}
