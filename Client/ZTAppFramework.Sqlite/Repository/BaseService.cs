using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.SqliteCore.Models;

namespace ZTAppFramework.SqliteCore.Repository
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  Zt
    /// 创建时间    ：  2022/9/5 9:28:50 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class BaseService<T>: DbContext where T : class, new()
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public async Task<SqlResult<long>> AddAsync(T parm, bool Async = true)
        {
            SqlResult<long>? res = new SqlResult<long>();
            try
            {
                var result = Async ? await freeSql.Insert<T>(parm).ExecuteIdentityAsync() : freeSql.Insert<T>(parm).ExecuteIdentity();
                res.data = result;
 
            }
            catch (Exception ex)
            {
                res.message = ex.Message;
                res.success = false;
            }
            return res;
        }

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        public async Task<SqlResult<T>> GetModelAsync(Expression<Func<T, bool>> where, bool Async = true)
        {
            var res = new SqlResult<T>
            {
                data = Async ? await freeSql.Queryable<T>().Where(where).FirstAsync()
                : freeSql.Queryable<T>().Where(where).First()
            };
            return res;
        }


        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public async Task<SqlResult<string>> UpdateAsync(T parm, bool Async = true)
        {
            var res = new SqlResult<string>() ;
            try
            {
                var dbres = Async ? await freeSql.GetRepository<T>().UpdateAsync(parm) : freeSql.GetRepository<T>().Update(parm);
                if (dbres <=0)
                    res.success = false;
                res.data = dbres.ToString();
                
            }
            catch (Exception ex)
            {
                res.success = false;
                res.message=ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获得列表，不需要任何条件
        /// </summary>
        /// <returns></returns>
        public async Task<SqlResult<List<T>>> GetListAsync(bool Async = true)
        {
            var res = new SqlResult<List<T>>();
            try
            {
                res.data = Async ? await freeSql.Queryable<T>().ToListAsync() : freeSql.Queryable<T>().ToList();
            }
            catch (Exception ex)
            {
                res.success = false;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
