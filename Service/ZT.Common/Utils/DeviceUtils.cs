using Masuit.Tools.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/12 13:59:30 
    /// Description   ：  终端帮助类
    ///********************************************/
    /// </summary>

    public class DeviceUtils
    {
        private static readonly DeviceUtils Instance = new DeviceUtils();
        private DeviceUtils() { }
        public static DeviceUtils GetInstance()
        {
            return Instance;
        }

        /// <summary>
        /// 是否Linux
        /// </summary>
        /// <returns></returns>
        private static bool IsUnix()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        #region 判断是否Mac，并支持其他类型判断
        private enum Platform
        {
            Windows,
            Linux,
            Mac
        }
        private Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }
        #endregion

        /// <summary>
        /// 获取资源使用信息
        /// </summary>
        /// <returns></returns>
        public DeviceUse GetMachineUseInfo()
        {
            var ramInfo = GetRamInfo();
            var diskInfo = GetDiskRate();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
            return new DeviceUse()
            {
                TotalRam = Math.Ceiling(ramInfo.Total / 1024).ToString() + " GB", // 总内存
                RamRate = Math.Ceiling(100 * ramInfo.Used / ramInfo.Total), // 内存使用率
                CpuRate = Math.Ceiling(double.Parse(GetCpuRate())), // cpu使用率
                DiskRate = Math.Ceiling(double.Parse(diskInfo)), //硬盘使用率
                RunTime = GetRunTime(),
                NetWorkUp = ipstat.ReceivedPackets,
                NetWorkDown = ipstat.ReceivedPacketsDelivered
            };
        }

        /// <summary>
        /// 获取基本参数
        /// </summary>
        /// <returns></returns>
        public dynamic GetMachineBaseInfo()
        {
            //var networkInfo = NetworkInfo.GetNetworkInfo();
            //var (Received, Send) = networkInfo.GetInternetSpeed(1000);
            var ramInfo = GetRamInfo();
            var list = new List<dynamic>
        {
            new {key = "HostName", value = Environment.MachineName},
            new {key = "MemTotal", value = ramInfo.Total},
            new {key = "SystemOs", value = RuntimeInformation.OSDescription},
            new {key="OsArchitecture",value=Environment.OSVersion.Platform + " " + RuntimeInformation.OSArchitecture},
            new {key="ProcessorCount",value=Environment.ProcessorCount + "核"},
            new {key="Is64BitProcess",value=Environment.Is64BitProcess}
        };
            return list;
            /*return new
            {
                //WanIp = await GetWanIpFromPCOnline(), // 外网IP
                SendAndReceived = "",// "上行" + Math.Round(networkInfo.SendLength / 1024.0 / 1024 / 1024, 2) + "GB 下行" + Math.Round(networkInfo.ReceivedLength / 1024.0 / 1024 / 1024, 2) + "GB", // 上下行流量统计
                LanIp = "",//networkInfo.AddressIpv4.ToString(), // 局域网IP
                IpMac = "",//networkInfo.Mac, // Mac地址
                HostName = Environment.MachineName, // HostName
                SystemOs = RuntimeInformation.OSDescription, // 系统名称
                OsArchitecture = Environment.OSVersion.Platform + " " + RuntimeInformation.OSArchitecture, // 系统架构
                ProcessorCount = Environment.ProcessorCount + "核", // CPU核心数
                NetworkSpeed = ""//"上行" + Send / 1024 + "kb/s 下行" + Received / 1024 + "kb/s" // 网络速度
            };*/
        }

        /// <summary>
        /// 获取CPU使用率
        /// </summary>
        /// <returns></returns>
        public string GetCpuRate()
        {
            string cpuRate;
            if (RunningPlatform() == Platform.Mac)
            {
                var output = ShellUtil.Bash("top -l 1 | head -n 10");
                var lines = output.Split("\n");
                var cpus = lines[3].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var n1 = cpus[2].Replace("%", "");
                var n2 = cpus[4].Replace("%", "");
                return (double.Parse(n1) + double.Parse(n2)).ToString(CultureInfo.InvariantCulture);
            }
            if (IsUnix())
            {
                var output = ShellUtil.Bash("top -b -n1 | grep \"Cpu(s)\" | awk '{print $2 + $4}'");
                cpuRate = output.Trim();
            }
            else
            {
                var output = ShellUtil.Cmd("wmic", "cpu get LoadPercentage");
                cpuRate = output.Replace("LoadPercentage", string.Empty).Trim();
            }
            return cpuRate;
        }

        /// <summary>
        /// 获得硬盘使用率
        /// </summary>
        /// <returns></returns>
        public string GetDiskRate()
        {
            if (IsUnix())
            {
                var output = ShellUtil.Bash("df -lh");
                var lines = output.Split("\n");
                double diskUse = 0;
                for (var i = 1; i < lines.Length - 1; i++)
                {
                    var disk = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    diskUse += double.Parse(disk[4].Replace("%", ""));
                }
                return diskUse.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 获取内存信息
        /// </summary>
        /// <returns></returns>
        public MemoryInfo GetRamInfo()
        {
            if (RunningPlatform() == Platform.Mac)
            {
                var output = ShellUtil.Bash("top -l 1 | head -n 10");
                var lines = output.Split("\n");
                var memory = lines[6].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var allMemoryStr = memory[1].Replace("G", "");
                var useMemory = memory[3].Replace("(", "").Replace("M", "");
                var free = double.Parse(allMemoryStr) * 1024 / double.Parse(useMemory);
                return new MemoryInfo
                {
                    Total = double.Parse(allMemoryStr) * 1024,
                    Used = double.Parse(useMemory),
                    Free = free
                };
            }
            if (IsUnix())
            {
                var output = ShellUtil.Bash("free -m");
                var lines = output.Split("\n");
                var memory = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                return new MemoryInfo
                {
                    Total = double.Parse(memory[1]),
                    Used = double.Parse(memory[2]),
                    Free = double.Parse(memory[3])
                };
            }
            else
            {
                var output = ShellUtil.Cmd("wmic", "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value");
                var lines = output.Trim().Split("\n");
                var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
                var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);
                var total = Math.Round(double.Parse(totalMemoryParts[1]) / 1024, 2);
                var free = Math.Round(double.Parse(freeMemoryParts[1]) / 1024, 2);
                return new MemoryInfo
                {
                    Total = total,
                    Free = free,
                    Used = total - free
                };
            }
        }

        /// <summary>
        /// 获取外网IP和地理位置
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetWanIpFromPCOnline()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var url = "http://whois.pconline.com.cn/ipJson.jsp";
            var stream = await HttpUtils.HttpGetAsync(url);
            var streamReader = new StreamReader(stream, Encoding.GetEncoding("GBK"));
            var html = await streamReader.ReadToEndAsync();
            var tmp = html[(html.IndexOf("({", StringComparison.Ordinal) + 2)..].Split(",");
            var ipAddr = tmp[0].Split(":")[1] + "【" + tmp[7].Split(":")[1] + "】";
            return ipAddr.Replace("\"", "");
        }

        /// <summary>
        /// 获取系统运行时间
        /// </summary>
        /// <returns></returns>
        private string GetRunTime()
        {
            return FormatTime((long)(DateTimeOffset.Now - Process.GetCurrentProcess().StartTime).TotalMilliseconds);
        }

        /// <summary>
        /// 毫秒转天时分秒
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        private string FormatTime(long ms)
        {
            int ss = 1000;
            int mi = ss * 60;
            int hh = mi * 60;
            int dd = hh * 24;

            long day = ms / dd;
            long hour = (ms - day * dd) / hh;
            long minute = (ms - day * dd - hour * hh) / mi;
            long second = (ms - day * dd - hour * hh - minute * mi) / ss;
            //long milliSecond = ms - day * dd - hour * hh - minute * mi - second * ss;

            string sDay = day < 10 ? "0" + day : "" + day; //天
            string sHour = hour < 10 ? "0" + hour : "" + hour;//小时
            string sMinute = minute < 10 ? "0" + minute : "" + minute;//分钟
            string sSecond = second < 10 ? "0" + second : "" + second;//秒
                                                                      //string sMilliSecond = milliSecond < 10 ? "0" + milliSecond : "" + milliSecond;//毫秒
                                                                      //sMilliSecond = milliSecond < 100 ? "0" + sMilliSecond : "" + sMilliSecond;
            return $"{sDay} 天 {sHour} 小时 {sMinute} 分 {sSecond} 秒";
        }
    }

    public class DeviceUse
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

    public class MemoryInfo
    {
        public double Total { get; set; }

        public double Used { get; set; }

        public double Free { get; set; }
    }

    /// <summary>
    /// 系统Shell命令
    /// </summary>
    public static class ShellUtil
    {
        /// <summary>
        /// Bash命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string Bash(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Dispose();
            return result;
        }

        /// <summary>
        /// cmd命令
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Cmd(string fileName, string args)
        {
            string output = null;
            var info = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                RedirectStandardOutput = true
            };
            using var process = Process.Start(info);
            if (process != null) output = process.StandardOutput.ReadToEnd();
            return output;
        }
    }
}
