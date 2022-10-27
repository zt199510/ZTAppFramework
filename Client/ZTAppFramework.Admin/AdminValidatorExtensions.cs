using FluentValidation;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Device;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFramework.Admin.Validations.Sys;
using ZTAppFramework.Admin.Validations.Sys.SysAdmin;
using ZTAppFramework.Admin.Validations.Sys.SysPost;
using ZTAppFramework.Admin.Validations.Users;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.Sys;
using ZTAppFreamework.Stared.Validations;

namespace ZTAppFramework.Admin
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/3 17:26:46 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class AdminValidatorExtensions
    {
        /// <summary>
        /// 注册验证
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterValidator(this IContainerRegistry services)
        {
            services.RegisterSingleton<GlobalValidator>();

            services.RegisterScoped<IValidator<UserLoginModel>, UserLoginValidator>();
            services.RegisterScoped<IValidator<UserEditPwdModel>, UserEditPwdValidator>();
            services.RegisterScoped<IValidator<SysOrganizeParm>, SysOrganizeParmValidator>();
            services.RegisterScoped<IValidator<SysRoleParm>, SysRoleParmValidator>();
            services.RegisterScoped<IValidator<SysPostParm>, SysPostParmValidator>();
            services.RegisterScoped<IValidator<SysAdminModel>, SysAdminParmValidator>();
            

        }

    }
}
