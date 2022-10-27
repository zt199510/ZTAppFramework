using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace ZTAppFramework.SqliteCore.Models
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/5 9:21:41 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class Account
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Guid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
