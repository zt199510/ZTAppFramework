using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.Commom;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFramewrok.Application.Stared.Sys;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class SysPostService : AppServiceBase
    {
        public override string ApiServiceUrl => "/api/SysPost";
        public SysPostService(ApiClinetRepository apiClinet) : base(apiClinet)
        {

        }

        [ApiUrl("Pages")]
        public async Task<AppliResult<PageResult<SysPostDto>>> GetPostList(PageParam pageParam)
        {
            AppliResult<PageResult<SysPostDto>> result = new AppliResult<PageResult<SysPostDto>>();
            var api = await _apiClinet.GetAsync<PageResult<SysPostDto>>(GetEndpoint(), pageParam);
            if (api.success && api.Code == 200)
            {
                result.Success = true;
                result.Message = api.message;
                result.data = api.data;
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }

        [ApiUrl("")]
        public async Task<AppliResult<bool>> Add(SysPostParm Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();

            var api = await _apiClinet.PostAsync<bool>(GetEndpoint(), Param);
            if (api.success&&api.Code==200)
            {
                result.Success = true;
                result.Message = "添加成功";
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }

        public async Task<AppliResult<bool>> Modif(SysPostParm Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();
            var api = await _apiClinet.PutAsync<bool>(GetEndpoint(), Param);
            if (api.success && api.Code == 200)
            {
                result.Success = true;
                result.Message = "添加成功";
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }

        [ApiUrl("")]
        public async Task<AppliResult<bool>> Delete(string Id)
        {
            AppliResult<bool> result = new AppliResult<bool>();
            var api = await _apiClinet.DeleteAsync<bool>(GetEndpoint(), new { Ids = Id });
            if (api.success && api.Code == 200)
            {
                result.Success = true;
                result.data = api.data;
                result.Message = api.message;
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }

            return result;
        }
    }
}
