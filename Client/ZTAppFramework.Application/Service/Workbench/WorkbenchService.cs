using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.SqliteCore.Implements;
using ZTAppFramework.SqliteCore.Models;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/15 16:46:09 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class WorkbenchService : AppServiceBase
    {

        public override string ApiServiceUrl => "/api/Workbench";
        public WorkbenchService(ApiClinetRepository apiClinet) : base(apiClinet)
        {

        }

        /// <summary>
        /// 获得资源使情况
        /// </summary>
        /// <returns></returns>
        [ApiUrl("MachineUse")]
        public async Task<AppliResult<DeviceUseDto>> GetMachineUse()
        {
            AppliResult<DeviceUseDto> result = new AppliResult<DeviceUseDto>();
            var r = await _apiClinet.GetAsync<DeviceUseDto>(GetEndpoint());
            if (r.success)
            {
                result.Success = true;
                result.data = r.data;
                result.Message = r.message;
            }
            else
            {
                result.Success = false;
                result.Message = r.message;
            }
            return result;
        }

        /// <summary>
        /// 获取内存信息
        /// </summary>
        /// <returns></returns>
        [ApiUrl("Memory")]
        public async  Task<AppliResult<MemoryInfoDto>> GetWorkBnchMemoryIno()
        {
            AppliResult<MemoryInfoDto> result = new AppliResult<MemoryInfoDto>();
            var r=await _apiClinet.GetAsync<MemoryInfoDto>(GetEndpoint());
            if (r.success)
            {
                result.Success = true;
                result.data = r.data;
                result.Message = r.message;
            }
            else
            {
                result.Success = false;
                result.Message = r.message;
            }
            return result;
        }

        [ApiUrl("Machine")]
        public async Task<AppliResult<List<MachineInfoDto>>> GetMachineInfo()
        {
            AppliResult<List<MachineInfoDto>> result = new AppliResult<List<MachineInfoDto>>();
            var r = await _apiClinet.GetAsync<List<MachineInfoDto>>(GetEndpoint());
            if (r.success)
            {
                result.Success = true;
                result.data = r.data;
                result.Message = r.message;
            }
            else
            {
                result.Success = false;
                result.Message = r.message;
            }
            return result;
        }

    }
}
