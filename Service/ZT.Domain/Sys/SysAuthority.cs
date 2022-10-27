using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 11:51:26 
    /// Description   ：  授权表
    ///********************************************/
    /// </summary>
    [SugarTable("sys_authority")]
    public class SysAuthority
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Required]
        public long RoleId { get; set; }

        /// <summary>
        /// 管理员编号
        /// </summary>
        public long AdminId { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public long MenuId { get; set; }

        /// <summary>
        /// 接口权限
        /// </summary>
        [SugarColumn(IsJson = true)]
        public List<SysMenuApiUrl> Api { get; set; } = new();

        /// <summary>
        /// 授权类型1=角色-菜单 2=用户-角色 3=角色-菜单-按钮功能
        /// </summary>
        [Required]
        public int Types { get; set; } = 1;


    }
}
