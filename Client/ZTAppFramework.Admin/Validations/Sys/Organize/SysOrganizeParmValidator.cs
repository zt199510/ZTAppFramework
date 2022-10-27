using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;

namespace ZTAppFramework.Admin.Validations.Sys
{
    public class SysOrganizeParmValidator : AbstractValidator<SysOrganizeParm>
    {
        public SysOrganizeParmValidator()
        {
            RuleFor(x => x.LeaderUser)
              .NotEmpty()
              .WithMessage("部门负责人不能为空！");
            RuleFor(x => x.ParentIdList)
            .NotEmpty()
            .WithMessage("所属机构不能为空！");

            RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("机构编码不能为空！");
            RuleFor(x => x.LeaderMobile)
            .NotEmpty()
            .WithMessage("联系电话不能为空！");
            RuleFor(x => x.LeaderEmail)
            .NotEmpty()
            .WithMessage("联系邮箱不能为空！");

        }
    }
}
