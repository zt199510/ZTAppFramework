using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Core.Jwt.Model
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:16:20 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class JwtConst
    {
        /// <summary>
        /// 受理人，强制Token失效
        /// 用户id，生成token和验证token的时候获取到持久化的值去校验
        /// 如果重新登陆，则刷新这个值
        /// </summary>
        public static string ValidAudience;
    }
}
