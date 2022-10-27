using System.Text.Json;
using ZT.Domain.Core.Result;

namespace ZT.ApiService.Configure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerAsync(context, ex);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new ApiResult<string>()
            {
                Code = 500,
                Message = ex.Message
            });

            await context.Response.WriteAsync(result.ToLower());
        }
    }
}
