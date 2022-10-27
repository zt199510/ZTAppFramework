using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Device
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/21 8:29:03 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class DeviceUseModel : BindableBase
    {
        private string _TotalRam;   //总内存
        private string _RunTime;    //服务器运行时间
        private double _RamRate;    //内存使用率
        private double _CpuRate;    //Cpu使用率
        private double _DiskRate;   //硬盘使用率
        private long _NetWorkUp;    // 网络上行
        private long _NetWorkDown;  // 网络下行
        public string TotalRam
        {
            get { return _TotalRam; }
            set { SetProperty(ref _TotalRam, value); }
        }

        public double RamRate
        {
            get { return _RamRate; ; }
            set { SetProperty(ref _RamRate, value); }
        }

        public double CpuRate
        {
            get { return _CpuRate; }
            set { SetProperty(ref _CpuRate, value); }
        }

        public double DiskRate
        {
            get { return _DiskRate; }
            set { SetProperty(ref _DiskRate, value); }
        }


        public string RunTime
        {
            get { return _RunTime; }
            set { SetProperty(ref _RunTime, value); }
        }

        public long NetWorkUp
        {
            get { return _NetWorkUp; }
            set { SetProperty(ref _NetWorkUp, value); }
        }

        public long NetWorkDown
        {
            get { return _NetWorkDown; }
            set { SetProperty(ref _NetWorkDown, value); }
        }
    }
}
