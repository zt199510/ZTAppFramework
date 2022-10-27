using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Common.Enum;

namespace ZT.Domain.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/8 14:23:14 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    [SugarTable("sys_message")]
    public class SysMessage : Entity
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        [Required]
        public long ColumnId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public MessageEnum Types { get; set; } = MessageEnum.System;

        /// <summary>
        /// 留言标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 邮箱信息
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 留言标签
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        [Required]
        public bool IsRead { get; set; } = false;

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required]
        public long UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 添加人
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
