using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 10:59:00 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class AppUtils
    {
        /// <summary>
        /// 注入对象服务提供类
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        public static IConfiguration Configuration;

        public static void InitConfig(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfigurationSection GetConfig(string path)
        {
            return Configuration.GetSection(path);
        }

        /// <summary>
        /// 手动获取注入的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetService<T>() where T : class
        {
            return ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext.RequestServices.GetService<T>();
        }


        private static string _mySqlConnectionString = string.Empty;
        /// <summary>
        /// MySql默认连接串
        /// </summary>
        public static string MySqlConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_mySqlConnectionString))
                {
                    _mySqlConnectionString = Configuration["SqlConnectionString:MySql"];
                }
                return _mySqlConnectionString;
            }
        }

        private static string _redisConnectionString = string.Empty;
        /// <summary>
        /// Redis默认连接串
        /// </summary>
        public static string RedisConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_redisConnectionString))
                {
                    _redisConnectionString = Configuration["Cache:Redis"];
                }
                return _redisConnectionString;
            }
        }
    }
}
