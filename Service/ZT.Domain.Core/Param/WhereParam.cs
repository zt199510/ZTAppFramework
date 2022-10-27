using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Core.Param
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/8 11:14:07 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class WhereParam : CommonParam
    {

    }


    public class WhereParam<T>
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public T Filter { get; set; }
    }

    /// <summary>
    /// 公共条件参数
    /// </summary>
    public class CommonParam
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 状态值  1=true  2=false  0=默认
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 时间，支持区间
        /// </summary>
        public string Times { get; set; }

    }
}
