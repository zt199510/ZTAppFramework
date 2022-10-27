using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Common.Utils;

namespace ZT.Domain
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:28:43 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class Entity
    {
        protected Entity()
        {
            Id = Unique.Id();
        }

        /// <summary>
        /// 唯一编号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }
    }
}
