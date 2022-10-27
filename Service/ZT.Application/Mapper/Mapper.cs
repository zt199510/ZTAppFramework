using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Application.Mapper
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/7 17:05:57 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class Mapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            /*config.ForType<User,UserDto>()
                .Map(dest => dest.UserAge, src => src.Age);*/
        }


    }

    /// <summary>
    /// 对象映射拓展类
    /// </summary>
    public static class MapperConfigExtensions
    {
        private static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = new TypeAdapterConfig();
            config.Default.PreserveReference(true);
            config.AllowImplicitSourceInheritance = true;
            config.AllowImplicitDestinationInheritance = true;

            /*config.NewConfig<WBaseEntity, WBaseEntity>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.ChangeDate)
                .Ignore(dest => dest.ChangeUserId);*/
            return config;
        }

        /// <summary>
        /// 添加对象映射
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static void AddMapperProfile(this IServiceCollection services)
        {
            // 获取全局映射配置
            var config = TypeAdapterConfig.GlobalSettings;

            var assemblyService = Assembly.Load("ZT.Application");
            // 扫描所有继承  IRegister 接口的对象映射配置
            config.Scan(assemblyService);

            // 配置默认全局映射（支持覆盖）
            config.Default
                .NameMatchingStrategy(NameMatchingStrategy.Flexible)
                .PreserveReference(true);

            // 配置支持依赖注入
            //services.AddSingleton(GetConfiguredMappingConfig());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
