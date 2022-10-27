using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared
{
    public class SysOrganizeParm
    {

        /// <summary>
        /// 唯一编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 机构编码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 部门负责人
        /// </summary>
        public string LeaderUser { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string LeaderEmail { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string LeaderMobile { get; set; }

        /// <summary>
        /// 父节点集合
        /// </summary>
        public List<string> ParentIdList { get; set; }

        /// <summary>
        /// 排序
        /// </summary>

        public int Sort { get; set; } = 1;

        /// <summary>
        /// 状态
        /// </summary>

        public bool Status { get; set; } = true;

    }
}
