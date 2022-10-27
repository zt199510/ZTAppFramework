using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Sugar.Filters
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:35:10 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class UnitOfWorkFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order => 100;

        /// <summary>
        /// SqlSugar 对象
        /// </summary>
        private readonly ISqlSugarClient _sqlSugarClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sqlSugarClient"></param>

        public UnitOfWorkFilter(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 获取动作方法描述器
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var method = actionDescriptor?.MethodInfo;

            // 判断是否贴有工作单元特性
            if (method != null && !method.IsDefined(typeof(UnitOfWorkAttribute), true))
            {
                _ = await next();
                return;
            }
            var attribute = (method?.GetCustomAttributes(typeof(UnitOfWorkAttribute), true).FirstOrDefault() as UnitOfWorkAttribute);

            // 开启事务
            if (attribute != null) _sqlSugarClient.Ado.BeginTran(attribute.IsolationLevel);
            // 调用方法
            var resultContext = await next();

            if (resultContext.Exception == null)
            {
                try
                {
                    _sqlSugarClient.Ado.CommitTran();
                }
                catch
                {
                    _sqlSugarClient.Ado.RollbackTran();
                }
                finally
                {
                    _sqlSugarClient.Ado.Dispose();
                }
            }
            else
            {
                _sqlSugarClient.Ado.RollbackTran();
                _sqlSugarClient.Ado.Dispose();
            }
        }

    }
}
