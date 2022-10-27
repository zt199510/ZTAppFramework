using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Domain.Core.Result
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:05:06 
    /// Description   ：   API 返回JSON格式
    ///********************************************/
    /// </summary>
    public class ApiResult<TObject>
    {
        /// <summary>
        /// PageResult
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; } = (int)HttpStatusCode.InternalServerError;

        /// <summary>
        /// 数据集
        /// </summary>
        public TObject Data { get; set; }

    }
}
