using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared.Sys
{ 
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/27 9:50:39 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysPostParm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public bool IsDel { get; set; }

        public int Sort { get; set; }

        public bool Status { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string Summary { get; set; }
    }
}
