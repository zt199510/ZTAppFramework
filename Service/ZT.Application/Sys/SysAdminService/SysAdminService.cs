using FytSoa.DynamicApi.Attributes;
using Mapster;
using Masuit.Tools.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZT.Common.Utils;
using ZT.Common.Utils.Config;
using ZT.Domain.Core.Cache;
using ZT.Domain.Core.Param;
using ZT.Domain.Core.Result;
using ZT.Domain.Sys;
using ZT.Sugar;
using ZT.Sugar.Extensions;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 10:16:19 
    /// Description   ：  管理员表服务接口
    ///********************************************/
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class SysAdminService : IApplicationService
    {

        private readonly SugarRepository<SysAdmin> _thisRepository;
        public SysAdminService(SugarRepository<SysAdmin> thisRepository)
        {
            _thisRepository = thisRepository;
        }


        /// <summary>
        /// 查询所有——分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PageResult<SysAdminDto>> GetPagesAsync(PageParam param)
        {
            var query = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.FullName.Contains(param.Key) || m.Mobile.Contains(param.Key) || m.Email.Contains(param.Key) ||
                                                               m.LoginAccount.Contains(param.Key))
                .WhereIF(!string.IsNullOrEmpty(param.Status), m => m.Status == (param.Status == "1"))
                .WhereIF(param.Id != 1 && param.Id != 0, m => m.RoleGroupParent.ToString()!.Contains(param.Id.ToString()))
                .ToPageAsync(param.Page, param.Limit);
            var result = query.Adapt<PageResult<SysAdminDto>>();
            if (result.Items.Count == 0)
            {
                return result;
            }
            var groupDb = _thisRepository.ChangeRepository<SugarRepository<SysRole>>();
            var groupList = await groupDb.GetListAsync();
            foreach (var item in result.Items)
            {
                var group = groupList.Where(m => item.RoleGroup.Contains(m.Id.ToString()));
                item.RoleGroupName = string.Join(",", group.Select(m => m.Name).ToArray()); ;
            }
            return result;
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SysAdminDto> GetAsync(long id)
        {
            var model = await _thisRepository.GetByIdAsync(id);
            model.LoginPassWord = model.LoginPassWord.AESDecrypt();
            return model.Adapt<SysAdminDto>();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddAsync(SysAdminDto model)
        {
            model.LoginPassWord = model.LoginPassWord.AESEncrypt();
            model.RoleGroup = new List<string>();
            foreach (var item in model.RoleGroupParent)
            {
                model.RoleGroup.Add(item.Last());
            }
            if (model.OrganizeIdList.Count > 0)
            {
                model.OrganizeId = long.Parse(model.OrganizeIdList.Last());
            }
            await _thisRepository.InsertAsync(model.Adapt<SysAdmin>());
        }

        /// <summary>
        /// 修改个人基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task ModifyBasicAsync(BasicParam model)
        {
            await _thisRepository.UpdateAsync(m => new SysAdmin()
            {
                FullName = model.FullName,
                Sex = model.Sex,
                Summary = model.Summary
            }, m => m.Id == model.Id);
        }


        /// <summary>
        /// 密码重置
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task PassResetAsync(List<long> id)
        {
            var newPwd = "123456a!".AESEncrypt();
            await _thisRepository.UpdateAsync(m => new SysAdmin()
            {
                LoginPassWord = newPwd
            }, m => id.Contains(m.Id));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
   
        public async Task ModifyAsync(SysAdminDto model)
        {
            model.LoginPassWord = model.LoginPassWord.AESEncrypt();
            model.RoleGroup = new List<string>();
            foreach (var item in model.RoleGroupParent)
            {
                model.RoleGroup.Add(item.Last());
            }
            if (model.OrganizeIdList.Count > 0)
            {
                model.OrganizeId = long.Parse(model.OrganizeIdList.Last());
            }
            await _thisRepository.UpdateAsync(model.Adapt<SysAdmin>());
        }

        /// <summary>
        /// 删除,支持多个
        /// </summary>
        /// <param name="ids">逗号分隔</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteAsync(string ids)
        {
            await _thisRepository.DeleteAsync(m => ids.StrToListLong().Contains(m.Id));
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="loginParam"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [NonDynamicMethod]
        public async Task<SysAdminDto> LoginAsync(LoginParam loginParam)
        {
            var code = MemoryService.Default.GetCache<string>(KeyUtils.CAPTCHACODE + loginParam.CodeKey);
            if (!string.Equals(code, loginParam.Code, StringComparison.CurrentCultureIgnoreCase)) throw new ArgumentException("验证码输入错误！~");

            var model = await _thisRepository.GetSingleAsync(m => !m.IsDel && m.LoginAccount == loginParam.Account);
            if (model == null) throw new ArgumentException("账号输入错误！~");

            if (model.LoginPassWord != loginParam.Password.AESEncrypt()) throw new ArgumentException("密码输入错误！~");

            if (!model.Status) throw new ArgumentException("账号被冻结，请联系管理员！~");
            model.LoginTime = DateTime.Now;
            model.LoginCount += 1;
            model.UpLoginTime = model.LoginTime;
            await _thisRepository.UpdateAsync(model);
            return model.Adapt<SysAdminDto>();
        }

   
    }
}
