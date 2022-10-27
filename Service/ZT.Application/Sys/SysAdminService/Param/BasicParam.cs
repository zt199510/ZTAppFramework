using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 14:07:16 
    /// Description   ：  个人信息基本修改
    ///********************************************/
    /// </summary>
    public class BasicParam
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public string Sex { get; set; }

        public string Summary { get; set; }
    }
}
