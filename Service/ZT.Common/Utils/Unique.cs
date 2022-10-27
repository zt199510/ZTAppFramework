using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/7 14:25:08 
    /// Description   ：  唯一值  -  雪花算法
    ///********************************************/
    /// </summary>
    public class Unique
    {
        private static readonly Unique Instance = new Unique();
        private Unique() { }
        private static IdWorker _worker;
        public static Unique GetInstance()
        {
            _worker = new IdWorker(1, 1);
            return Instance;
        }

        /// <summary>
        /// 返回唯一ID值
        /// </summary>
        /// <returns></returns>
        public static long Id()
        {
            return _worker.NextId();
        }
    }
}
