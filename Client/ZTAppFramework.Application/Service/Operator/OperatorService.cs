using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFramewrok.Application.Stared;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/22 13:49:23 
    /// Description   ：  用户信息服务
    ///********************************************/
    /// </summary>
    public class OperatorService : AppServiceBase
    {
        public override string ApiServiceUrl => "/api/Operator";
        public OperatorService(ApiClinetRepository apiClinet) : base(apiClinet)
        {

        }
    
        [ApiUrl("UserWord")]
        public async Task<AppliResult<OperatorWordDto>> GetUserWordInfo()
        {
            AppliResult<OperatorWordDto> res = new AppliResult<OperatorWordDto>() {  Message = "未知异常" };
            var api = await _apiClinet.GetAsync<OperatorWordDto>(GetEndpoint());
            if (api.success)
            {
                res.data = api.data;
                res.Success = true;
            }
            else
            {
                res.Success = false;
            }

            return res;
        }

        [ApiUrl("EditPassword")]
        public async Task<AppliResult<bool>> EditPassword(OperatroPasswordParam param)
        {
            AppliResult<bool> res = new AppliResult<bool>() { Message = "未知异常" };
            var api = await _apiClinet.PostAsync<bool>(GetEndpoint(), param);
            if (api.success)
            {
                if (api.Code != 200) {
                    res.data = api.data;
                    res.Message = api.message;
                    res.Success = false;
                }
                else
                {
                    res.data = api.data;
                    res.Message = "密码修改成功";
                    res.Success = true;
                }
              
            }
            else
            {
                res.Success = false;
            }

            return res;
        }
    }
}
