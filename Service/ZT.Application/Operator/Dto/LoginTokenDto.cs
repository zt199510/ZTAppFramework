using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Operator
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 10:15:11 
    /// Description   ：  
    ///********************************************/
    /// </summary>

    public class LoginTokenDto
    {
        public string accessToken { get; set; }

        public OperatorUser userInfo { get; set; }
    }
}
