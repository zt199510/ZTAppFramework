using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZT.Application.Filters;
using ZT.Common.Utils;
using ZT.Domain.Core.Cache;
using ZT.Domain.Core.Result;

namespace ZT.ApiService.Controllers
{
    /// <summary>
    /// 验证码
    /// </summary>
   
    public class CaptchaController : ApiController
    {
        [HttpGet("{identify}"), AllowAnonymous, NoJsonResult, NoAuditLog]
        public async Task<IActionResult> Get(string identify)
        {
            if (string.IsNullOrEmpty(identify))
            {
                identify = CommonUtils.GetIp();
            }
            var code = await CaptchaUtils.GenerateRandomCaptchaAsync(4);
            MemoryService.Default.SetCache(KeyUtils.CAPTCHACODE + identify, code, 5);
            //var captcha = await CaptchaUtils.GenerateCaptchaImageAsync(code);
            //return File(captcha.ms.ToArray(), "image/gif");

            return Ok(new ApiResult<string>() { Data=code });
        }


        
        [HttpGet("Get123")]
        public ActionResult<string> SayHello()
        {
            return "Hello World";
        }
    }
}
