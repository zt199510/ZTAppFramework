using FytApi.MUI;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ZT.ApiService.Swagger
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
              
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ZT Project",
                });

                s.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "ZT Project",
                });

                s.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "ZT Project",
                });

                s.SwaggerDoc("v4", new OpenApiInfo
                {
                    Version = "v4",
                    Title = "ZT Project",
                });

                s.SwaggerDoc("v5", new OpenApiInfo
                {
                    Version = "v5",
                    Title = "ZT App",
                });
                s.OrderActionsBy(o => o.RelativePath);

                //Add Xml
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile), true);
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ZT.Application.xml"), true);
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ZT.Domain.xml"), true);

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "accessToken",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             }
                         },
                         new string[] {}
                     }
                });

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "接口文档-Sys");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "接口文档-Cms");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "接口文档-Mem");
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "接口文档-Shop");
                c.SwaggerEndpoint("/swagger/v5/swagger.json", "接口文档-App");
            });
            app.UseFytApiUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sys", "v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Cms", "v2");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "Mem", "v3");
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "Shop", "v4");
                c.SwaggerEndpoint("/swagger/v5/swagger.json", "App", "v5");
            });

        }
    }
}
