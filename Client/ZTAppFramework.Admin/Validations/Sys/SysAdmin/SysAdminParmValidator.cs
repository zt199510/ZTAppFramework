using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramewrok.Application.Stared;

namespace ZTAppFramework.Admin.Validations.Sys.SysAdmin
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/28 11:48:51 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysAdminParmValidator : AbstractValidator<SysAdminModel>
    {
        public SysAdminParmValidator()
        {
            RuleFor(x => x.FullName)
           .NotEmpty()
           .WithMessage("姓名不能为空！");
            RuleFor(x => x.LoginAccount)
            .NotEmpty()
            .WithMessage("账号不能为空！");
            RuleFor(x => x.LoginPassWord)
            .NotEmpty()
            .WithMessage("账号不能为空！");
            RuleFor(x => x.OrganizeIdList)
            .NotEmpty()
            .WithMessage("所属部门不能为空！");

            RuleFor(x => x.PostGroup)
            .NotEmpty()
            .WithMessage("所属岗位不能为空！");

            RuleFor(x => x.RoleGroupParent)
            .NotEmpty()
            .WithMessage("所属角色不能为空！");
        }
    }
}
