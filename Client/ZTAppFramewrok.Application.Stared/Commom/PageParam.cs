using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared
{
    public class PageParam
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每页多少条
        /// </summary>
        public int Limit { get; set; } = 10;
        public string Key { get; set; }

        public long? Id { get; set; }
    }

   
}
