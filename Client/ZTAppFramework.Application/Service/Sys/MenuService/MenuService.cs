using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// 创建时间    ：  2022/9/6 10:30:32 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class MenuService : AppServiceBase
    {

        public override string ApiServiceUrl => "api/SysMenu";
        public MenuService(ApiClinetRepository apiClinet) : base(apiClinet)
        {

        }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        [ApiUrl("List")]
        public async Task<AppliResult<ObservableCollection<SysMenuDto>>> GetMenuList()
        {
            AppliResult<ObservableCollection<SysMenuDto>> res = new AppliResult<ObservableCollection<SysMenuDto>>() { Success = false, Message = "未知异常",data=new ObservableCollection<SysMenuDto>() };

            var api = await _apiClinet.GetAsync<List<SysMenuDto>>(GetEndpoint(),_apiClinet._accessTokenManager.userInfo.Id);
            if (api.success)
            {
                foreach (var item in api.data)
                {
                    var info= res.data.FirstOrDefault(x => x.Id == item.ParentId);
                    if (info != null)
                    {
                        if (info.Childer == null) info.Childer = new ObservableCollection<SysMenuDto>();
                        info.Childer.Add(item);
                    }
                    else
                        res.data.Add(item);
                }
                res.Success = true;
                res.Message = api.message;
            }
            return res;
        }
    }
}
