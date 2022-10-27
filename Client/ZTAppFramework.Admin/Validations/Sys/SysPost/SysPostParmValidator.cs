using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared.Sys;

namespace ZTAppFramework.Admin.Validations.Sys.SysPost
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/27 10:04:12 
    /// Description   ：  岗位管理参数验证
    ///********************************************/
    /// </summary>
    public class SysPostParmValidator : AbstractValidator<SysPostParm>
    {
        public SysPostParmValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("岗位名称不能为空！");
            RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("岗位编号不能为空！");
        }
    }
}
