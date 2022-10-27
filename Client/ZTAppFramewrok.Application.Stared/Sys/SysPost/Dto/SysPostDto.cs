using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared
{
    /// <summary>
    /// 职位管理Dto
    /// </summary>
    public class SysPostDto
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
    
        public string Name { get; set; }

        /// <summary>
        /// 岗位编码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 排序
        /// </summary>

        public int Sort { get; set; } = 1;

        /// <summary>
        /// 岗位状态
        /// </summary>
  
        public bool Status { get; set; } = true;

        /// <summary>
        /// 删除状态
        /// </summary>
    
        public bool IsDel { get; set; } = false;

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
    
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
