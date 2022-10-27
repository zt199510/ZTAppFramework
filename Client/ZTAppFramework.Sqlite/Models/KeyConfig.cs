using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.SqliteCore.Models
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/5 13:41:46 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class KeyConfig
    {
        [Column(IsPrimary = true)]
        public string Key { get; set; }

        public string Values { get; set; }

        public bool Check { get; set; }

    }
}
