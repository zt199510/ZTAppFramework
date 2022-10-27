using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared.HttpManager;

namespace ZTAppFramework.Application.Service
{
    public class CaptchaService : AppServiceBase
    {
        public override string ApiServiceUrl => "/api/Captcha";
        public CaptchaService(ApiClinetRepository apiClinet) : base(apiClinet)
        {

        }

        public async Task<AppliResult<string>> GetCaptchaAsync(string CodeKey="123123")
        {
            AppliResult<string> result = new AppliResult<string>() { Success = false };
            var api = await _apiClinet.GetAnonymousAsync<string>(GetEndpoint()+ $"{CodeKey}");
            if (api.success)
            {
                result.Success = true;
                result.data = api.data;
            }
            else
            {
                result.Message = api.message;
            }
              
            return result;
        }
    }
}
