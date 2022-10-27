using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZT.Common.Utils.Config;
using ZT.Domain.Core.Param;
using ZT.Domain.Core.Result;
using ZT.Domain.Sys;
using ZT.Sugar;
using ZT.Sugar.Extensions;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 13:44:05 
    /// Description   ：  组织服务接口
    ///********************************************/
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class SysOrganizeService : IApplicationService
    {
        private readonly SugarRepository<SysOrganize> _thisRepository;
        public SysOrganizeService(SugarRepository<SysOrganize> thisRepository)
        {
            _thisRepository = thisRepository;
        }

        /// <summary>
        /// 查询所有——分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PageResult<SysOrganizeDto>> GetPagesAsync(PageParam param)
        {
            var query = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.Name.Contains(param.Key))
                .ToPageAsync(param.Page, param.Limit);
            return query.Adapt<PageResult<SysOrganizeDto>>();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysOrganizeDto>> GetListAsync(WhereParam param)
        {
            var list = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.Name.Contains(param.Key))
                .OrderBy(m => m.Id, OrderByType.Desc).ToListAsync();
            return list.Adapt<List<SysOrganizeDto>>();
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SysOrganizeDto> GetAsync(long id)
        {
            var model = await _thisRepository.GetByIdAsync(id);
            return model.Adapt<SysOrganizeDto>();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(SysOrganizeDto model)
        {
            if (model.ParentIdList.All(m => m != "0"))
            {
                model.ParentId = long.Parse(model.ParentIdList.Last());
                var paramModel = await _thisRepository.GetByIdAsync(model.ParentId);
                model.Layer = paramModel.Layer + 1;
                model.ParentIdList.Add(model.Id.ToString());
            }
            else
            {
                model.ParentIdList = new List<string> { model.Id.ToString() };
            }

            var upModel = await _thisRepository.GetFirstAsync(m => true, m => m.Sort);
            model.Sort = upModel.Sort + 1;
            return await _thisRepository.InsertAsync(model.Adapt<SysOrganize>());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> ModifyAsync(SysOrganizeDto model)
        {
            if (model.ParentIdList.All(m => m != "0"))
            {
                model.ParentId = long.Parse(model.ParentIdList.Last());
                model.ParentIdList.Add(model.Id.ToString());
            }
            else
            {
                model.ParentIdList = new List<string> { model.Id.ToString() };
            }
            return await _thisRepository.UpdateAsync(model.Adapt<SysOrganize>());
        }

        /// <summary>
        /// 删除,支持多个
        /// </summary>
        /// <param name="ids">逗号分隔</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteAsync(string ids)
        {
            return await _thisRepository.DeleteAsync(m => ids.StrToListLong().Contains(m.Id));
        }

        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task ColSort(SortParam param)
        {
            int a = 0, b = 0, c = 0;
            var list = await _thisRepository.GetListAsync(m => m.ParentId == param.Parent, m => m.Sort, Common.Enum.OrderEnum.Asc);
            if (list.Count <= 0) return;
            var index = 0;
            foreach (var item in list)
            {
                index++;
                if (index == 1)
                {
                    if (item.Id != param.Id) continue;
                    if (param.Type != 1) continue;
                    a = item.Sort;
                    b = list[index].Sort;
                    c = a;
                    a = b;
                    b = c;
                    item.Sort = a;
                    await _thisRepository.UpdateAsync(item);
                    var nitem = list[index];
                    nitem.Sort = b;
                    await _thisRepository.UpdateAsync(nitem);
                    break;
                }
                if (index == list.Count)
                {
                    if (item.Id != param.Id) continue;
                    if (param.Type != 0) continue;
                    a = item.Sort;
                    b = list[index - 2].Sort;
                    c = a;
                    a = b;
                    b = c;
                    item.Sort = a;
                    await _thisRepository.UpdateAsync(item);
                    var nitem = list[index - 2];
                    nitem.Sort = b;
                    await _thisRepository.UpdateAsync(nitem);
                    break;
                }
                if (item.Id != param.Id) continue;
                if (param.Type == 1) //下降一位
                {
                    a = item.Sort;
                    b = list[index].Sort;
                    c = a;
                    a = b;
                    b = c;
                    item.Sort = a;
                    await _thisRepository.UpdateAsync(item);
                    var nitem = list[index];
                    nitem.Sort = b;
                    await _thisRepository.UpdateAsync(nitem);
                    break;
                }
                else
                {
                    a = item.Sort;
                    b = list[index - 2].Sort;
                    c = a;
                    a = b;
                    b = c;
                    item.Sort = a;
                    await _thisRepository.UpdateAsync(item);
                    var nitem = list[index - 2];
                    nitem.Sort = b;
                    await _thisRepository.UpdateAsync(nitem);
                    break;
                }
            }
        }

    }
}
