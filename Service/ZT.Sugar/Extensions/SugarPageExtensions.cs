using Mapster;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Domain.Core.Result;

namespace ZT.Sugar.Extensions
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:32:41 
    /// Description   ：  分页扩展
    ///********************************************/
    /// </summary>
    public static class SugarPageExtensions
    {
        public static async Task<PageResult<T>> ToPageAsync<T>(this ISugarQueryable<T> query,
            int pageIndex,
            int pageSize, bool isMapper = true)
        {
            RefAsync<int> totalItems = 0;
            var items = await query.ToPageListAsync(pageIndex, pageSize, totalItems);
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            return new PageResult<T>()
            {
                Items = isMapper ? items.Adapt<List<T>>() : items,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
    }
}
