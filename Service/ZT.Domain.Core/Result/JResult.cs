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
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/7 14:05:30 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class JResult<TObject>
    {
        public static ApiResult<TObject> Error(string errMsg)
        {
            return new ApiResult<TObject>
            {
                Code = -1,
                Message = errMsg
            };
        }

        public static ApiResult<TObject> Error()
        {
            return new ApiResult<TObject>
            {
                Code = (int)HttpStatusCode.InternalServerError,
                Message = "服务端发生错误"
            };
        }

        public static ApiResult<TObject> Success()
        {
            return new ApiResult<TObject>
            {
                Code = (int)HttpStatusCode.OK
            };
        }

        public static ApiResult<TObject> Success(TObject resultData)
        {
            return new ApiResult<TObject>
            {
                Code = (int)HttpStatusCode.OK,
                Data = resultData
            };
        }
    }
}
