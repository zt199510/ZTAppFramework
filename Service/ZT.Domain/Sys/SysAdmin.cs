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
    /// 创建时间    ：  2022/9/8 10:21:50 
    /// Description   ：  管理员表
    ///********************************************/
    /// </summary>
    [SugarTable("sys_admin")]
    public class SysAdmin : Entity
    {
        /// <summary>
        /// 所属角色
        /// </summary>
        [Required]
        [StringLength(200)]
        [SugarColumn(IsJson = true)]
        public List<string> RoleGroup { get; set; }

        /// <summary>
        /// 所属角色，包含父级
        /// </summary>
        [SugarColumn(IsJson = true)]
        public List<List<string>> RoleGroupParent { get; set; }

        /// <summary>
        /// 所属岗位
        /// </summary>
        [Required]
        [StringLength(200)]
        [SugarColumn(IsJson = true)]
        public List<string> PostGroup { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [Required]
        public long OrganizeId { get; set; }

        /// <summary>
        /// 所属上级部门组
        /// </summary>
        [SugarColumn(IsJson = true)]
        public List<string> OrganizeIdList { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [Required]
        [StringLength(30)]
        public string LoginAccount { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        [StringLength(200)]
        public string LoginPassWord { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPic { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public bool Status { get; set; } = true;

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool IsDel { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        public string Summary { get; set; }

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

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? UpLoginTime { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [Required]
        public int LoginCount { get; set; } = 0;


    }
}
