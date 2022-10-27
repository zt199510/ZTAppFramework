using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZT.Application.Operator.Dto;
using ZT.Application.Sys;
using ZT.Common.Enum;
using ZT.Common.Utils;
using ZT.Common.Utils.Config;
using ZT.Domain.Core.Jwt;
using ZT.Domain.Core.Jwt.Model;
using ZT.Domain.Core.Result;
using ZT.Domain.Sys;
using ZT.Sugar;

namespace ZT.Application.Operator
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:12:09 
    /// Description   ：  操作人服务
    ///********************************************/
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class OperatorService : IApplicationService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SysAdminService _adminService;
        private readonly SysOrganizeService _organizeService;
        private readonly SysLogService _logService;
        private readonly SugarRepository<SysOrganize> _thisRepository;

        public OperatorService(IHttpContextAccessor httpContextAccessor
            , SysAdminService adminService
            , SysOrganizeService organizeService
            , SysLogService logService
            , SugarRepository<SysOrganize> thisRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _adminService = adminService;
            _organizeService = organizeService;
            _logService = logService;
            _thisRepository = thisRepository;
        }


        public OperatorUser User => GetTokenUser();
        [HttpGet]
        private OperatorUser GetTokenUser()
        {
            var paramToken = _httpContextAccessor.HttpContext?.Request.Headers["accessToken"].ToString();
            if (string.IsNullOrEmpty(paramToken))
            {
                return new OperatorUser();
            }
            var token = JwtAuthService.SerializeJwt(paramToken);
            return new OperatorUser()
            {
                Id = token.Id,
                RoleArray = token.RoleArray.StrToListLong(),
                TenantId = token.TenantId,
                Username = token.FullName,
            };
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginParam"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<LoginTokenDto> LoginAsync(LoginParam loginParam)
        {
            var loginRes = await _adminService.LoginAsync(loginParam);

            var token = JwtAuthService.IssueJwt(new JwtToken()
            { Id = loginRes.Id, FullName = loginRes.FullName, Role = "Admin", RoleArray = string.Join(",", loginRes.RoleGroup), Time = DateTime.Now });
            var user = await _adminService.GetAsync(loginRes.Id);

            #region 登录日志收集
            await _logService.AddAsync(new SysLogDto()
            {
                Level = LogEnum.Info,
                LogType = LogTypeEnum.Login,
                Module = "Login",
                Method = "Login",
                OperateUser = user.FullName,
                Parameters = JsonSerializer.Serialize(loginParam),
                IP = CommonUtils.GetIp(),
                Address = "/api/login",
                Browser = CommonUtils.GetBrowser(),
            });
            #endregion

            return new LoginTokenDto()
            {
                accessToken = token,
                userInfo = new OperatorUser()
                {
                    Id = user.Id,
                    Username = user.FullName,
                    Avatar = user.HeadPic
                }
            };
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="ModifPwdParam"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost]
        public async Task<bool> EditPasswordAsync(OperatroPasswordDto ModifPwdParam)
        {
            if (ModifPwdParam.NewPassword != ModifPwdParam.VerifyNewPassword) throw new ArgumentException("两次密码不一致！~");
            var loginRes =  GetTokenUser();
            var user = await _adminService.GetAsync(loginRes.Id);
            user.LoginPassWord = ModifPwdParam.NewPassword;
            await _adminService.ModifyAsync(user);
            return true;
        }

        /// <summary>
        /// 查询登录人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<OperatorUser> UserInfo()
        {
            var paramToken = _httpContextAccessor.HttpContext?.Request.Headers["accessToken"].ToString();
            if (string.IsNullOrEmpty(paramToken))
            {
                return new OperatorUser();
            }
            var token = JwtAuthService.SerializeJwt(paramToken);
            var model = await _adminService.GetAsync(token.Id);
            return new OperatorUser()
            {
                Id = model.Id,
                Username = model.FullName,
                Avatar = model.HeadPic
            };
        }

        /// <summary>
        /// 工作台用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<OperatorWorkDto> UserWord()
        {
            var paramToken = _httpContextAccessor.HttpContext?.Request.Headers["accessToken"].ToString();
            if (string.IsNullOrEmpty(paramToken))
            {
                return new OperatorWorkDto();
            }
            var token = JwtAuthService.SerializeJwt(paramToken);
            var model = await _adminService.GetAsync(token.Id);
            var organize = await _organizeService.GetAsync(model.OrganizeId);
            var roleList = await _thisRepository.Context.Queryable<SysRole>()
                .Where(m => model.RoleGroup.Contains(m.Id.ToString())).ToListAsync();
            var postList = await _thisRepository.Context.Queryable<SysPost>()
                .Where(m => model.PostGroup.Contains(m.Id.ToString())).ToListAsync();
            var messageCount = await _thisRepository.Context.Queryable<SysMessage>().CountAsync(m => true);
            var agencyCount = await _thisRepository.Context.Queryable<SysMessage>().CountAsync(m => !m.IsRead);
            return new OperatorWorkDto()
            {
                Account = model.LoginAccount,
                fullName = model.FullName,
                sex = model.Sex,
                headPic = model.HeadPic,
                organize = organize.Name,
                summary = model.Summary,
                role = roleList.Select(m => m.Name).ToList(),
                post = postList.Select(m => m.Name).ToList(),
                lastTime = model.UpLoginTime,
                loginSum = model.LoginCount,
                messageSum = messageCount,
                agencySum = agencyCount
            };
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<int> Logout()
        {
            // var paramToken=_httpContextAccessor.HttpContext?.Request.Headers["accessToken"].ToString();
            // //加入到黑名单中，在中间件判断 token是否在黑名单，如果在，则默认为假的token，重新登录
            // var blackList = RedisService.Instance.Get<List<string>>(KeyUtils.JWTBLACKLIST);
            // blackList.Add(paramToken);
            // RedisService.Instance.SetJson(KeyUtils.JWTBLACKLIST,blackList);
            return JResult<int>.Success();
        }

    }
}
