using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZT.Common.Enum;
using ZT.Common.Utils;

namespace ZT.Sugar
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:23:58 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SugarRepository<T> : SimpleClient<T> where T : class, new()
    {
        public SugarRepository(ISqlSugarClient? context = null) : base(context)
        {
            Context = AppUtils.GetService<ISqlSugarClient>();
            if (Context == null) return;
            Context.Aop.DataExecuting = (oldValue, entityInfo) =>
            {
                //新增操作
                if (entityInfo.OperationType == DataFilterType.InsertByObject)
                {
                    if (entityInfo.EntityColumnInfo.IsPrimarykey &&
                        entityInfo.EntityColumnInfo.PropertyInfo.PropertyType == typeof(long))
                    {
                        entityInfo.SetValue(Unique.Id());
                    }

                    if (entityInfo.PropertyName == "CreateUser")
                    {
                        entityInfo.SetValue("Admin");
                    }
                }

                //更新操作
                if (entityInfo.OperationType != DataFilterType.UpdateByObject) return;
                if (entityInfo.PropertyName == "UpdateUser")
                {
                    entityInfo.SetValue("Admin");
                }

                if (entityInfo.PropertyName == "UpdateTime")
                {
                    entityInfo.SetValue(DateTime.Now);
                }
            };
            Context.Aop.OnLogExecuting = (s, p) =>
            {
                var sqlValue = string.Empty;
                foreach (var item in p)
                {
                    sqlValue += item.ParameterName + "参数：" + item.Value + "\r\n";
                }
                //Console.WriteLine("Sql脚本："+s+"\r\n"+string.Join(",", p.Select(it => it.ParameterName + ":" + it.Value)));
                // Logger.Info("Sql脚本："+s+"\r\n"+sqlValue);
            };
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页条数</param>
        /// <param name="order">排序</param>
        /// <param name="orderEnum">枚举，1=desc 2=asc</param>
        /// <returns>集合、总条数、总页数</returns>
        public async Task<(List<T>, int totalItem, int totalPage)> GetPageResultAsync(Expression<Func<T, bool>> where, int page, int limit, Expression<Func<T, object>> order, OrderEnum orderEnum = OrderEnum.Desc)
        {
            RefAsync<int> totalItems = 0;
            var list = await Context.Queryable<T>()
                .Where(where)
                .OrderBy(order, (int)orderEnum == 1 ? OrderByType.Desc : OrderByType.Asc)
                .ToPageListAsync(page, limit, totalItems);
            var sumPage = totalItems != 0 ? (totalItems % page) == 0 ? (totalItems / limit) : (totalItems / limit) + 1 : 0;
            return (list, totalItems, sumPage);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="where">Expression 条件</param>
        /// <param name="strWhere">string 条件</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页条数</param>
        /// <param name="order">排序</param>
        /// <param name="orderEnum">枚举，1=desc 2=asc</param>
        /// <returns>集合、总条数、总页数</returns>
        public async Task<(List<T>, int totalItem, int totalPage)> GetPageResultAsync(Expression<Func<T, bool>> where, string strWhere, int page, int limit, Expression<Func<T, object>> order, OrderEnum orderEnum = OrderEnum.Desc)
        {
            RefAsync<int> totalItems = 0;
            var list = await Context.Queryable<T>()
                .Where(where)
                .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                .OrderBy(order, (int)orderEnum == 1 ? OrderByType.Desc : OrderByType.Asc)
                .ToPageListAsync(page, limit, totalItems);
            var sumPage = totalItems != 0 ? (totalItems % page) == 0 ? (totalItems / limit) : (totalItems / limit) + 1 : 0;
            return (list, totalItems, sumPage);
        }

        /// <summary>
        /// 根据条件，获得最新的一条数据
        /// </summary>
        /// <param name="where">拉姆达条件</param>
        /// <param name="order">拉姆达排序</param>
        /// <param name="orderEnum">枚举，1=desc 2=asc</param>
        /// <returns></returns>
        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, OrderEnum orderEnum = OrderEnum.Desc)
        {
            return await Context.Queryable<T>()
                .Where(where)
                .OrderBy(order, (int)orderEnum == 1 ? OrderByType.Desc : OrderByType.Asc)
                .FirstAsync() ?? new T();
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        /// <param name="where">拉姆达条件</param>
        /// <param name="order">拉姆达排序</param>
        /// <param name="orderEnum">枚举，1=desc 2=asc</param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> where,
            Expression<Func<T, object>> order, OrderEnum orderEnum = OrderEnum.Desc)
        {
            var query = Context.Queryable<T>()
                .Where(where)
                .OrderBy(order, (int)orderEnum == 1 ? OrderByType.Desc : OrderByType.Asc);
            return await query.ToListAsync();
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        /// <param name="where">拉姆达条件</param>
        /// <param name="order">order by id desc</param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> where,
            string order)
        {
            var query = Context.Queryable<T>()
                .Where(where)
                .OrderByIF(!string.IsNullOrEmpty(order), order);
            return await query.ToListAsync();
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        /// <param name="where">拉姆达条件</param>
        /// <param name="expression">拉姆达排序</param>
        /// <returns></returns>
        public async Task<int> SumAsync(Expression<Func<T, bool>> where, Expression<Func<T, int>> expression)
        {
            var query = Context.Queryable<T>()
                .Where(where);
            return await query.SumAsync(expression);
        }

    }
}
