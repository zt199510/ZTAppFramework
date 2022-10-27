using FluentValidation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFreamework.Stared.Validations
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间      ：  2022/9/3 17:14:20 
    /// Description   ：  验证器扩展
    ///********************************************/
    /// </summary>
    public static class ValidatorExtensions
    {

        /// <summary>
        /// 属性属于必填项验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            string errorMessage = "")
        {
            return ruleBuilder.SetValidator(new NotEmptyValidator<T, TProperty>()).WithMessage(errorMessage);
        }

        /// <summary>
        /// 最大长度验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="maximumLength"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MaxLength<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int maximumLength,
            string errorMessage = "")
        {
            return ruleBuilder.SetValidator(new MaximumLengthValidator<T>(maximumLength)).WithMessage(errorMessage);
        }

        /// <summary>
        /// 最小长度验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="minimumLength"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MinLength<T>(this IRuleBuilder<T, string> ruleBuilder,
            int minimumLength,
            string errorMessage = "")
        {
            return ruleBuilder.SetValidator(new MinimumLengthValidator<T>(minimumLength)).WithMessage(errorMessage);
        }

        /// <summary>
        /// 邮箱验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="mode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Email<T>(
           this IRuleBuilder<T, string> ruleBuilder,
           EmailValidationMode mode = EmailValidationMode.AspNetCoreCompatible,
           string errorMessage = "")
        {
#pragma warning disable 618
            var validator = mode == EmailValidationMode.AspNetCoreCompatible ?
                new AspNetCoreCompatibleEmailValidator<T>() :
                (PropertyValidator<T, string>)new EmailValidator<T>();
#pragma warning restore 618
            return ruleBuilder.SetValidator(validator).WithMessage(errorMessage);
        }

        /// <summary>
        /// 正则表达式验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="expression"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Regular<T>(this IRuleBuilder<T, string> ruleBuilder,
            string expression,
            string errorMessage = "")
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>(expression)).WithMessage(errorMessage);
        }
    }
}
