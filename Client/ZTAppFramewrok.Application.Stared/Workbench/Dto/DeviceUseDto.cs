using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/15 16:50:15 
    /// Description   ：  CPU配置
    ///********************************************/
    /// </summary>
    public class DeviceUseDto
    {
        public string TotalRam { get; set; }
        public double RamRate { get; set; }
        public double CpuRate { get; set; }
        public double DiskRate { get; set; }
        public string RunTime { get; set; }
        /// <summary>
        /// 网络上行
        /// </summary>
        public long NetWorkUp { get; set; }
        /// <summary>
        /// 网络下行
        /// </summary>
        public long NetWorkDown { get; set; }

    }
}
