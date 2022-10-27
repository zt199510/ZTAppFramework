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
    /// 创建时间    ：  2022/9/7 14:16:05 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class JwtModel
    {
        public const string Name = "JwtAuth";
        public string Security { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int WebExp { get; set; }
    }
}
