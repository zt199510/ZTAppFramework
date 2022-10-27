using ZT.Domain.Core.Jwt.Model;
using ZT.Domain.Core.Jwt;
using System.Text.Json;
using ZT.Domain.Core.Result;

namespace ZT.ApiService.Configure.Middleware
{
    public class JwtMiddleware
    {
        private readonly List<string> _ignoreApi = new()
    {
        "/api/operator/login",
        "swagger",
        "/api/captcha/",
        "/api/quartz/job",
        "/fytapiui",
        "/chathub",
        "/api-config",
        "/fyt",
        "/upload"
    };
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                return _next(context);
            }
            var headers = context.Request.Headers;
            //过滤，不要验证token的url
            var path = context.Request.Path.Value?.ToLower();
            var isIgnore = false;
            foreach (var item in _ignoreApi.Where(item => path != null && path.Contains(item)))
            {
                isIgnore = true;
            }
            if (isIgnore)
            {
                return _next(context);
            }
            //自动刷新token
            var token = headers["accessToken"];
            if (string.IsNullOrEmpty(token))
            {
                return JwtTokenHandlerAsync(context);
            }
            var jwtToken = JwtAuthService.SerializeJwt(token);
            var ts = DateTime.Now.Subtract(jwtToken.Time);
            if (ts.Minutes is <= 30 or >= 60) return _next(context);
            var newToken = JwtAuthService.IssueJwt(new JwtToken() { Id = jwtToken.Id, FullName = jwtToken.FullName, Role = "Admin", RoleArray = jwtToken.RoleArray, Time = DateTime.Now });
            context.Response.Headers.Add("X-Refresh-Token", newToken);


            return _next(context);
        }

        private async Task JwtTokenHandlerAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new ApiResult<string>()
            {
                Code = 401,
                Message = "无权限"
            });
            await context.Response.WriteAsync(result.ToLower());
        }
    }
}
