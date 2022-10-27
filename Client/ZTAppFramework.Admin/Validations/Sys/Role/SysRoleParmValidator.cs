using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;

namespace ZTAppFramework.Admin.Validations.Sys
{
    public class SysRoleParmValidator: AbstractValidator<SysRoleParm>
    {
        public SysRoleParmValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("角色名称不能为空！");
            RuleFor(x => x.ParentIdList)
            .NotEmpty()
            .WithMessage("所属角色不能为空！");
        }
    }
}
