using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Microsoft.Extensions.FileProviders;
using ZT.ApiService.Configure.Filters;
using ZT.ApiService.Configure.Middleware;
using ZT.ApiService.Hubs;
using ZT.ApiService.Swagger;
using ZT.Application.Mapper;
using ZT.Common.Extensions;
using ZT.Common.Utils;
using ZT.CrossCutting;
using ZT.Sugar.Filters;

var builder = WebApplication.CreateBuilder(args);
// SignalR
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSignalR();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "FytSoaCors",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:2800")
//                .AllowAnyHeader()
//                .AllowAnyMethod()
//                .AllowCredentials()
//                .WithExposedHeaders("X-Refresh-Token");
//        });
//});

// Add services to the container.
AppUtils.InitConfig(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AopActionFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<UnitOfWorkFilter>();
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.AllowTrailingCommas = false;
    options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
    options.JsonSerializerOptions.Converters.Add(new LongJsonConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// Register DI
builder.Services.RegisterServices();

// Mapper
builder.Services.AddMapperProfile();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ZTCors", policy =>
    {
        policy.WithOrigins("http://localhost:2800")
                .AllowAnyHeader()
          .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerSetup();
}
app.UseSwaggerSetup();
app.UseStaticFiles();

app.UseFileServer(new FileServerOptions
{
    //FileProvider = new PhysicalFileProvider(
       /// Path.Combine(Directory.GetCurrentDirectory(), "upload")),
   // RequestPath = "/upload",
});

app.UseSetup();

app.MapControllers().RequireAuthorization();
app.MapHub<ChatHub>("/chathub");

app.Run();