using Mapster;
using Microsoft.AspNetCore.Mvc;
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
    /// 创建时间    ：  2022/9/8 11:06:43 
    /// Description   ：  角色服务接口
    ///********************************************/
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class SysRoleService : IApplicationService
    { 
        private readonly SugarRepository<SysRole> _thisRepository;
        public SysRoleService(SugarRepository<SysRole> thisRepository)
        {
            _thisRepository = thisRepository;
        }

        /// <summary>
        /// 查询所有——分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PageResult<SysRoleDto>> GetPagesAsync(PageParam param)
        {
            var query = await _thisRepository.AsQueryable()
                .ToPageAsync(param.Limit, param.Page);
            return query.Adapt<PageResult<SysRoleDto>>();
        }


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysRoleDto>> GetListAsync(WhereParam param)
        {
            var list = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.Name.Contains(param.Key))
                .ToListAsync();
            return list.Adapt<List<SysRoleDto>>();
        }


        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SysRoleDto> GetAsync(long id)
        {
            var model = await _thisRepository.GetByIdAsync(id);
            return model.Adapt<SysRoleDto>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(SysRoleDto model)
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
            return await _thisRepository.InsertAsync(model.Adapt<SysRole>());
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> ModifyAsync(SysRoleDto model)
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
            return await _thisRepository.UpdateAsync(model.Adapt<SysRole>());
        }



        /// <summary>
        /// 删除,支持多个
        /// </summary>
        /// <param name="ids">逗号分隔</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteAsync(string ids) =>
            await _thisRepository.DeleteAsync(m => ids.StrToListLong().Contains(m.Id));

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
