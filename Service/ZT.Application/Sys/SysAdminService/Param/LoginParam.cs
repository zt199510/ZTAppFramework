using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 10:16:36 
    /// Description   ：  登录参数
    ///********************************************/
    /// </summary>
    public class LoginParam
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// 验证码Key
        /// </summary>
        [Required]
        public string CodeKey { get; set; }
    }
}
