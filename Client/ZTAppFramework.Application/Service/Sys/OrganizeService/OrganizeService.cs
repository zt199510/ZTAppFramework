using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFramewrok.Application.Stared.HttpManager.Model;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/7 8:26:15 
    /// Description   ：  组织管理服务
    ///********************************************/
    /// </summary>
    public class OrganizeService : AppServiceBase
    {

        public override string ApiServiceUrl => "/api/SysOrganize";
        public OrganizeService(ApiClinetRepository apiClinet) : base(apiClinet)
        {


        }

        [ApiUrl("List")]
        public async Task<AppliResult<List<SysOrganizeDto>>> GetList(string Key)
        {
            AppliResult<List<SysOrganizeDto>> result = new AppliResult<List<SysOrganizeDto>>() { data = new List<SysOrganizeDto>() };
           
            var api=await _apiClinet.GetAsync<List<SysOrganizeDto>>(GetEndpoint(),new {Key=Key});
            if (api.success)
            {
                if (api.Code == 200)
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
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }
        [ApiUrl("")]
        public async Task<AppliResult<bool>> Modif(SysOrganizeDto Parmam)
        {
            AppliResult<bool> result = new AppliResult<bool>();

            var api = await _apiClinet.PutAsync<bool>(GetEndpoint(), Parmam);
            if (api.success)
            {
                if (api.Code == 200)
                {
                    result.Success = true;
                    result.Message = "修改成功";
                   
                }
                else
                {
                    result.Success = false;
                    result.Message = api.message;
                }
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }

        [ApiUrl("")]
        public async Task<AppliResult<bool>> Add(SysOrganizeParm Parmam)
        {
            AppliResult<bool> result = new AppliResult<bool>();

            var api = await _apiClinet.PostAsync<bool>(GetEndpoint(), Parmam);
            if (api.success)
            {
                if (api.Code == 200)
                {
                    result.Success = true;
                    result.Message = "添加成功";

                }
                else
                {
                    result.Success = false;
                    result.Message = api.message;
                }
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
            if (api.success&&api.Code==200)
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
