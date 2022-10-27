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
    /// 创建时间    ：  2022/9/8 11:09:59 
    /// Description   ：  角色表
    ///********************************************/
    /// </summary>
    public class SysRoleDto
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 角色父节点
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 父节点结合
        /// </summary>
        public List<string> ParentIdList { get; set; }

        /// <summary>
        /// 角色层级
        /// </summary>
        [Required]
        public int Layer { get; set; } = 1;

        /// <summary>
        /// 角色编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        [Required]
        public bool IsSystem { get; set; } = false;

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public bool Status { get; set; } = true;

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; } = 1;

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 控制台
        /// </summary>
        public string Console { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool IsDel { get; set; } = false;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser { get; set; }


    }
}
