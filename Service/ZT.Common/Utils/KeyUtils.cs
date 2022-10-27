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
    /// 创建时间    ：  2022/9/7 16:47:55 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class KeyUtils
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public static string NOWSITE = "NOWSITE";

        /// <summary>
        /// 管理菜单
        /// </summary>
        public static string ADMINMENU = "ADMINMENU";

        /// <summary>
        /// 广告位
        /// </summary>
        public static string WEBCMSADV = "WEBCMSADV";

        /// <summary>
        /// 网站信息 
        /// </summary>
        public static string WEBCMSSITE = "WEBCMSSITE";

        /// <summary>
        /// Redis连接对象
        /// </summary>
        public static string REDISLOCALHOST = "Cache:Redis";

        /// <summary>
        /// Des加解密秘钥
        /// </summary>
        public static string DESKEY = "Security:DesKey";

        /// <summary>
        /// 邮箱信息
        /// </summary>
        public static string EMAILCONFIG = "Email:Config";

        /// <summary>
        /// 保存验证码标识
        /// </summary>
        public static string CAPTCHACODE = "CAPTCHACODE";

        /// <summary>
        /// Jwt黑名单
        /// </summary>
        public static string JWTBLACKLIST = "JWTBLACKLIST";

        /// <summary>
        /// 系统安全设置
        /// </summary>
        public static string SYSTEMSAFETY = "SYSTEMSAFETY";

        /// <summary>
        /// 在线用户
        /// </summary>
        public static string ONLINEUSERS = "ONLINEUSERS";

        /// <summary>
        /// Redis 存储授权API
        /// </summary>
        public static string AUTHORIZZATIONAPI = "AUTHORIZZATIONAPI";

        /// <summary>
        /// 读取配置文件，超级角色的编号
        /// </summary>
        public static string SUPERROLEID = "Oauth:SuperRole";
    }
}
