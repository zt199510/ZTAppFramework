using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Common.Enum;
using ZT.Domain.Core.Param;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/10/12 10:37:28 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysLogParam : PageParam
    {
        public LogEnum Level { get; set; }

        public LogTypeEnum Type { get; set; }
    }
}
