using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZT.Common.Utils;

namespace ZT.Application.Operator
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class WorkbenchService : IApplicationService
    {

        /// <summary>
        /// 获得资源使情况
        /// </summary>
        /// <returns></returns>
        public DeviceUse GetMachineUse()
        {
            return DeviceUtils.GetInstance().GetMachineUseInfo();
        }

        /// <summary>
        /// 获得系统信息
        /// </summary>
        /// <returns></returns>
        public dynamic GetMachine()
        {
            return DeviceUtils.GetInstance().GetMachineBaseInfo();
        }

        /// <summary>
        /// 读取CPU使用率
        /// </summary>
        /// <returns></returns>
        public double GetCpu()
        {
            return Math.Ceiling(double.Parse(DeviceUtils.GetInstance().GetCpuRate()));
        }

        /// <summary>
        /// 读取硬盘使用率
        /// </summary>
        /// <returns></returns>
        public double GetDisk()
        {
            var diskInfo = DeviceUtils.GetInstance().GetDiskRate();
            return double.Parse(diskInfo);
        }

        /// <summary>
        /// 读取内存使用率
        /// </summary>
        /// <returns></returns>
        public double GetMemory()
        {
            var ramInfo = DeviceUtils.GetInstance().GetRamInfo();
            return Math.Ceiling(100 * ramInfo.Used / ramInfo.Total);
        }

    }
}
