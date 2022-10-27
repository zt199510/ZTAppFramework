using FytSoa.DynamicApi;
using FytSoa.Quartz.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZT.Common.Utils;
using ZT.Domain.Core.Cache;
using ZT.Generator;
using ZT.Sugar;

namespace ZT.CrossCutting
{
    public static class BootStrapperIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // application services
            var assemblyService = Assembly.Load("ZT.Application");
            var serviceType = assemblyService.GetTypes().Where(u => u.IsClass && !u.IsAbstract && !u.IsGenericType && u.Name.EndsWith("Service")).ToList();
            foreach (var item in serviceType.Where(s => !s.IsInterface))
            {
                services.AddScoped(item);
            }

            services.AddMemoryCache();

            // cache
            services.AddScoped<ICacheService, MemoryService>();

            // code generator
           // services.AddScoped<IGeneratorService, GeneratorService>();

            services.SqlSugarSetup();

            // log
            Logger.AddLogger();

            // id
            Unique.GetInstance();

            // Quartz
           // services.AddQuartz();
          //  services.AddQuartzClassJobs();

            // dynamic webapi
            services.AddDynamicWebApi();

            // Jwt Config
            services.AddJwtConfiguration();
        }
    }
}