using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Operator.Dto
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/23 16:28:12 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class OperatroPasswordDto
    {
        public string CurrnetPassword { get; set; }
        public string NewPassword { get; set; }

        public string VerifyNewPassword { get; set; }
    }
}
