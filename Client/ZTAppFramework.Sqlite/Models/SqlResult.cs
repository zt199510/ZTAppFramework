using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.SqliteCore.Models
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/5 9:31:39 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SqlResult<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; } = true;
        /// <summary>
        /// 信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 数据集
        /// </summary>
        public T data { get; set; }
    }
}
