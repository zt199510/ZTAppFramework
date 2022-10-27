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
    /// 创建时间    ：  2022/9/8 11:46:12 
    /// Description   ：  资源菜单表
    ///********************************************/
    /// </summary>
    [SugarTable("sys_menu")]
    public class SysMenu : Entity
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 父节点集合组
        /// </summary>
        [SugarColumn(IsJson = true)]
        public List<string> ParentIdList { get; set; } = new();

        /// <summary>
        /// 权限标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 菜单层级
        /// </summary>
        [Required]
        public int Layer { get; set; } = 1;

        /// <summary>
        /// 路由地址
        /// </summary>
        public string Urls { get; set; }

        /// <summary>
        /// 重定向
        /// </summary>
        public string Redirect { get; set; }

        /// <summary>
        /// Vue文件路径
        /// </summary>
        public string VuePath { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 高亮
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; } = 1;

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
        /// 菜单类型
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Types { get; set; }

        /// <summary>
        /// 接口权限
        /// </summary>
        [SugarColumn(IsJson = true)]
        public List<SysMenuApiUrl> Api { get; set; } = new();

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


    /// <summary>
    /// 接口权限
    /// </summary>
    public class SysMenuApiUrl
    {
        /// <summary>
        /// 权限标识
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// Api url
        /// </summary>
        public string url { get; set; }
    }
}
