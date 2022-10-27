using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using ZTAppFramework.SqliteCore.Implements;
using ZTAppFramework.SqliteCore.Models;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.Commom;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFreamework.Stared;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    public class AdminService : AppServiceBase
    {
        private readonly UserLocalSerivce _userLocalSerivce;
        private readonly KeyConfigLocalService _keyConfigLocalService;

        public override string ApiServiceUrl => "/api/SysAdmin";
        public AdminService(ApiClinetRepository apiClinet, UserLocalSerivce userLocalSerivce, KeyConfigLocalService keyConfigLocalService) : base(apiClinet)
        {
            _userLocalSerivce = userLocalSerivce;
            _keyConfigLocalService = keyConfigLocalService;
        }

        /// <summary>
        /// 获取账号存储信息
        /// </summary>
        /// <returns></returns>
        public async Task<AppliResult<KeyConfig>> GetLocalAccountInfo()
        {
            var r = await _keyConfigLocalService.GetUserSaveInfo();
            return new AppliResult<KeyConfig>() { data = r.data };
        }

        /// <summary>
        /// 获取账号记录
        /// </summary>
        /// <returns></returns>
        public async Task<AppliResult<List<LoginParam>>> GetLocalAccountList()
        {
            AppliResult<List<LoginParam>> result = new AppliResult<List<LoginParam>>();
            var Csql = await _userLocalSerivce.GetListAsync();
            if (Csql.success)
            {
                result.data = new List<LoginParam>();
                Csql.data.ForEach(x => result.data.Add(new LoginParam() { Account = x.Name, Password = x.Password }));
            }
            else
            {
                result.Success = false;
            }

            return result;
        }
        public async Task<AppliResult<string>> SaveLocalAccountInfo(bool Save, LoginParam user)
        {
            AppliResult<string> result = new AppliResult<string>();

            var d = await _keyConfigLocalService.GetModelAsync(x => x.Key == AppKeys.SaveUserInfoKey);
            if (d.data != null)
            {
                d.data.Values = user.Account;
                d.data.Check = Save;
                var r = await _keyConfigLocalService.UpdateAsync(d.data);
                if (r.success)
                    result.Message = "保存成功";
            }
            return result;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<AppliResult<string>> LoginServer(LoginParam user)
        {
            AppliResult<string> res = new AppliResult<string>() { Success = false, Message = "未知异常" };
            ApiResult<LoginTokenDto> api = await _apiClinet.PostAnonymousAsync<LoginTokenDto>("/api/Operator/Login", user);
            if (api.success)
            {
                if (api.Code == 200)
                {
                    res.Success = true;
                    var info = await _userLocalSerivce.GetModelAsync(x => x.Name == user.Account);
                    if (info.data == null)
                    {
                        var CSql = await _userLocalSerivce.AddAsync(new SqliteCore.Models.Account() { Name = user.Account, Password = user.Password });
                    }
                    else
                    {
                        info.data.Password=user.Password;
                        var CSql = await _userLocalSerivce.UpdateAsync(info.data);
                    }
                    _apiClinet.SetToken(api.data);
                }
                else
                {
                    res.Message = api.message;
                }
            }
            else
            {
                res.Message = api.message;
            }
            return res;
        }


        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <returns></returns>
        [ApiUrl("Basic")]
        public async Task<AppliResult<string>> MoifBasic(OperatorWordDto dto)
        {
            AppliResult<string> result = new AppliResult<string>();
            dto.Id = _apiClinet._accessTokenManager.userInfo.Id;
            var api = await _apiClinet.PutAsync<string>(GetEndpoint(), dto);
            if (api.success)
            {
                if (api.Code == 200)
                {
                    result.Success = true;
                    result.Message = "修改信息成功";
                }
            }
            else
            {
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }


        [ApiUrl("Pages")]
        public async Task<AppliResult<PageResult<SysAdminDto>>> GetPostList(PageParam pageParam)
        {
            AppliResult<PageResult<SysAdminDto>> result = new AppliResult<PageResult<SysAdminDto>>();
            var api = await _apiClinet.GetAsync<PageResult<SysAdminDto>>(GetEndpoint(), pageParam);
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
        public async Task<AppliResult<bool>> Add(SysAdminDto Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();
            var api=await _apiClinet.PostAsync<bool>(GetEndpoint(), Param);
            if (api.success && api.Code == 200)
            {
                result.data = api.data;
                result.Success = true;
                result.Message = "添加成功!";
            }
            else
            {
                result.data = api.data;
                result.Success = false;
                result.Message = api.message;
            }
            return result;
        }

        [ApiUrl("")]
        public async Task<AppliResult<bool>> Modif(SysAdminDto Param)
        {
            AppliResult<bool> result = new AppliResult<bool>();
            var api = await _apiClinet.PutAsync<bool>(GetEndpoint(), Param);
            if (api.success && api.Code == 200)
            {
                result.data = api.data;
                result.Success = true;
                result.Message = "修改成功!";
            }
            else
            {
                result.data = api.data;
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
