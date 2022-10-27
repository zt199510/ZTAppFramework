using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/10/12 10:38:36 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class TimeUtils
    {
        /// <summary>
        /// 分割时间，查询作用
        /// </summary>
        /// <param name="timeStr"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static (string beginTime, string endTime) Splitting(string timeStr, char split = '/')
        {
            var time = timeStr.Split(new char[] { split }, StringSplitOptions.RemoveEmptyEntries);
            return (time[0], time[1]);
        }
    }
}
