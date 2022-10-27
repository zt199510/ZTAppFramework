using FreeRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZT.Common.Utils;

namespace ZT.Domain.Core.Cache
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 17:12:18 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class RedisService
    {
        public static RedisClient cli => new(AppUtils.RedisConnectionString);

        public static readonly RedisService Instance;
        static RedisService()
        {
            Instance = new RedisService();
        }

        /// <summary>
        /// 查询Redis信息
        /// </summary>
        /// <param name="redisKey"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T? Get<T>(string redisKey) where T : class, new()
        {
            var redisStr = cli.Get(redisKey);
            return !string.IsNullOrEmpty(redisStr) ? JsonSerializer.Deserialize<T>(redisKey) : null;
        }

        /// <summary>
        /// 查询Redis信息
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public void SetJson<T>(string redisKey, T t)
        {
            cli.Set(redisKey, JsonSerializer.Serialize(t));
        }
    }
}
