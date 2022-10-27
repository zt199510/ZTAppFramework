using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ZT.Domain.Core.Result;
using ZT.Application.Sys;
using ZT.Common.Enum;
using ZT.Application.Operator;

namespace ZT.ApiService.Configure.Filters
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {

        readonly IWebHostEnvironment _hostEnvironment;
        private SysLogService _logService;
        private OperatorService _operatorService;
        public GlobalExceptionFilter(IWebHostEnvironment hostEnvironment
            , SysLogService logService
            , OperatorService operatorService)
        {
            _hostEnvironment = hostEnvironment;
            _logService = logService;
            _operatorService = operatorService;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled) return;

            #region 保存异常日志
            var type = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerTypeInfo.AsType();
            if (type != null)
            {
                var logInfo = new SysLogDto()
                {
                    Level = LogEnum.Error,
                    LogType = LogTypeEnum.Operate,
                    Module = type.FullName,
                    Method = context.HttpContext.Request.Method,
                    OperateUser = _operatorService.User.Username,
                    IP = context.HttpContext.Connection.RemoteIpAddress?.ToString(),
                    Address = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString,
                    Browser = context.HttpContext.Request.Headers["User-Agent"].ToString(),
                    Message = context.Exception.Message
                };
                //保存日志信息
                await _logService.AddAsync(logInfo);
            }
            #endregion

            var result = new ApiResult<string?>
            {
                Code = 500,
                //Message = "服务器发生未处理的异常"
                Message = context.Exception.Message
            };
            if (_hostEnvironment.IsDevelopment())
            {
                result.Message = context.Exception.Message;
                result.Data = context.Exception.StackTrace;
            }
            context.Result = new JsonResult(result);
            context.ExceptionHandled = true;
        }
    }
}
