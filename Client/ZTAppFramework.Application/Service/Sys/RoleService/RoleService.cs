using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/26 14:16:10 
    /// Description   ：  角色管理服务
    ///********************************************/
    /// </summary>
    public class RoleService : AppServiceBase
    {
        public override string ApiServiceUrl => "/api/SysRole";
        public RoleService(ApiClinetRepository apiClinet) : base(apiClinet)
        {
        }

        [ApiUrl("List")]
        public async Task<AppliResult<List<SysRoleDto>>> GetList(string Key="")
        {
            AppliResult<List<SysRoleDto>> result = new AppliResult<List<SysRoleDto>>() ;

            var api = await _apiClinet.GetAsync<List<SysRoleDto>>(GetEndpoint(), new { Key = Key });
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
        public async Task<AppliResult<bool>> Modif(SysRoleParm Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();

            var api = await _apiClinet.PutAsync<bool>(GetEndpoint(), Param);
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
        public async Task<AppliResult<bool>> Add(SysRoleParm Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();

            var api = await _apiClinet.PostAsync<bool>(GetEndpoint(), Param);
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
