using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.SqliteCore.Implements;

namespace ZTAppFramework.SqliteCore
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/5 9:47:17 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class RegisterStaredSqlite
    {
        public static void RegisterSqliteManager(this IContainerRegistry services)
        {
            services.RegisterScoped<UserLocalSerivce>();
            services.RegisterScoped<KeyConfigLocalService>();
        }

    }
}
