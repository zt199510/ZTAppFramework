using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFreamework.Stared.Validations;

namespace ZTAppFramework.Admin.Validations.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/3 17:23:07 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("用户长度不能为空！")
                .Length(5, 30)
                .WithMessage("用户长度限制在5到30个字符之间！");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("密码长度不能为空！")
                .Length(5, 30)
                .WithMessage("密码长度限制在5到30个字符之间！");
        }
    }
}
