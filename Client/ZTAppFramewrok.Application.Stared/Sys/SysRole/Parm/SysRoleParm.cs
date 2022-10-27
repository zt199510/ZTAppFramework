using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared
{
    public class SysRoleParm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ParentId { get; set; }

        public bool IsSystem { get; set; } = false;

        public List<string> ParentIdList { get; set; }

        public bool IsDel { get; set; } = false;
        public bool Status { get; set; } = true;

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string CreateUser { get; set; }

        public int Sort { get; set; } = 1;

        public int Layer { get; set; } = 1;

        public string Summary { get; set; }
    }
}
