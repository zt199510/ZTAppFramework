using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Operator
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/8 14:21:47 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class OperatorUser
    {
        /// <summary>
        /// 登录人ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        public long TenantId { get; set; } = 0;

        /// <summary>
        /// 登录人信息
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 登录人信息
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 控制台权限
        /// </summary>
        public int Dashboard { get; set; } = 0;

        /// <summary>
        /// 权限
        /// </summary>
        public List<string> Ability { get; set; } = new() { "READ", "WRITE", "DELETE" };

        /// <summary>
        /// 角色组
        /// </summary>
        public List<long> RoleArray { get; set; } = new();

        /// <summary>
        /// 权限
        /// </summary>
        public List<string> Roles { get; set; } = new() { "admin" };
    }
}
