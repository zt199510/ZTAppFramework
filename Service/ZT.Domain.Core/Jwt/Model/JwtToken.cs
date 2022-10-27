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
    /// 创建时间    ：  2022/9/7 14:15:53 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class JwtToken
    {
        public long Id { get; set; }

        public long TenantId { get; set; } = 0;

        public string RoleArray { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public DateTime Time { get; set; } = new();
    }
}
