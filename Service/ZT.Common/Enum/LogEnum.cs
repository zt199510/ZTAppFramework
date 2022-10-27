using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Enum
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 13:57:54 
    /// Description   ：  日志级别枚举
    ///********************************************/
    /// </summary>
    public enum LogEnum
    {
        Debug = 1,
        Info = 2,
        Warn = 3,
        Error = 4,
        Fatal = 5
    }

    public enum LogTypeEnum
    {
        Login = 1,
        Operate = 2
    }

}
