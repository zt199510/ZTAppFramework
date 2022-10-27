using Newtonsoft.Json;
using Serilog;
using Serilog.Filters;
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
    /// 创建时间    ：  2022/9/7 16:57:46 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class Logger
    {
        static string ApiLog = "apilog";
        static string ErrorLog = "errorlog";

        /// <summary>
        /// 初始化日志
        /// </summary>
        public static void AddLogger()
        {
            var basePath = $@"{AppContext.BaseDirectory}logs/";
            FileUtils.CreateFolder(basePath + ApiLog);
            FileUtils.CreateFolder(basePath + ErrorLog);
            static string LogFilePath(string fileName) => $@"{AppContext.BaseDirectory}logs/{fileName}/log.log";
            var serilogOutputTemplate = "{NewLine}Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}LogLevel："
                                        + "{Level}{NewLine}Message：{Message}{NewLine}{Exception}"
                                        + new string('-', 100);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                //.WriteTo.File(formatter:new CompactJsonFormatter(),"logs\\test.txt",rollingInterval:RollingInterval.Day)
                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(Matching.WithProperty<string>("position", p => p == ApiLog)).WriteTo.Async(a => a.File(LogFilePath(ApiLog), rollingInterval: RollingInterval.Day, outputTemplate: serilogOutputTemplate)))
                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(Matching.WithProperty<string>("position", p => p == ErrorLog)).WriteTo.Async(a => a.File(LogFilePath(ErrorLog), rollingInterval: RollingInterval.Day, outputTemplate: serilogOutputTemplate)))
                .CreateLogger();
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fileName"></param>
        public static void Info(string msg, string fileName = "")
        {
            if (fileName == "" || fileName == ApiLog)
            {
                Log.Information($"{{position}}:{msg}", ApiLog);
            }
            else
            {
                //输入其他的话，还是存放到ApiLog文件夹
                Log.Information($"{{position}}:{msg}", ApiLog);
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="obj">对象</param>
        /// <param name="fileName"></param>
        public static void Info(string msg, object obj, string fileName = "")
        {
            if (fileName == "" || fileName == ApiLog)
            {
                Log.Information($"{{position}}:{msg}-{JsonConvert.SerializeObject(obj)}", ApiLog);
            }
            else
            {
                //输入其他的话，还是存放到ApiLog文件夹
                Log.Information($"{{position}}:{msg}-{JsonConvert.SerializeObject(obj)}", ApiLog);
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            Log.Error(ex, "{position}:" + ex.Message, ErrorLog);
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            Log.Error($"{{position}}:{msg}", ApiLog);
        }
    }
}
