using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Users;

namespace ZTAppFramework.Admin.Validations.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/23 15:24:09 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class UserEditPwdValidator : AbstractValidator<UserEditPwdModel>
    {
        public UserEditPwdValidator()
        {
            RuleFor(x => x.CurrnetPassword)
             .NotEmpty()
             .WithMessage("当前密码长度不能为空！")
             .Length(5, 30)
             .WithMessage("当前密码长度限制在5到30个字符之间！");

            RuleFor(x => x.NewPassword)
              .NotEmpty()
              .WithMessage("新密码长度不能为空！")
              .Length(5, 30)
              .WithMessage("新密码长度限制在5到30个字符之间！");

            RuleFor(x => x.VerifyNewPassword)
             .NotEmpty()
             .WithMessage("新密码长度不能为空！")
             .Length(5, 30)
             .WithMessage("新密码长度限制在5到30个字符之间！").Must(ReEqualsNew).WithMessage("两次密码不一致");
    
        }

        private bool ReEqualsNew(UserEditPwdModel model, string newPwd)
        {
            return model.NewPassword == newPwd;
        }
    }
}
