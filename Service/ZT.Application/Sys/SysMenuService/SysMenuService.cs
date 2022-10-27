using FytSoa.DynamicApi.Attributes;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Application.Operator;
using ZT.Common.Enum;
using ZT.Common.Utils;
using ZT.Common.Utils.Config;
using ZT.Domain.Core.Cache;
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
    /// 创建时间    ：  2022/9/8 11:45:23 
    /// Description   ：  菜单服务接口
    ///********************************************/
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    public class SysMenuService : IApplicationService
    {
        private readonly OperatorService _operatorService;
        private readonly SugarRepository<SysMenu> _thisRepository;
        public SysMenuService(OperatorService operatorService
            , SugarRepository<SysMenu> thisRepository)
        {
            _operatorService = operatorService;
            _thisRepository = thisRepository;
        }

        /// <summary>
        /// 查询所有——分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PageResult<SysMenuDto>> GetPagesAsync(PageParam param)
        {
            var query = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.Name.Contains(param.Key))
                .ToPageAsync(param.Page, param.Limit);
            return query.Adapt<PageResult<SysMenuDto>>();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysMenuDto>> GetListAsync(WhereParam param)
        {
            var list = await _thisRepository.AsQueryable()
                .WhereIF(!string.IsNullOrEmpty(param.Key), m => m.Name.Contains(param.Key))
                .ToListAsync();
            return list.Adapt<List<SysMenuDto>>();
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SysMenuDto> GetAsync(long id)
        {
            var model = await _thisRepository.GetByIdAsync(id);
            return model.Adapt<SysMenuDto>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(SysMenuDto model)
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
            return await _thisRepository.InsertAsync(model.Adapt<SysMenu>());
        }

        /// <summary>
        /// 添加-临时=未命名
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<SysMenuDto> AddTempAsync(SysMenuTempParam param)
        {
            var model = new SysMenu()
            {
                Name = param.Name,
                ParentId = param.ParentId,
                Types = "menu",
            };
            model.ParentIdList =
                param.ParentId != 0
                    ? new List<string>() { param.ParentId.ToString(), model.Id.ToString() }
                    : new List<string> { model.Id.ToString() };

            var upModel = await _thisRepository.GetFirstAsync(m => true, m => m.Sort);
            model.Sort = upModel.Sort + 1;

            await _thisRepository.InsertAsync(model);
            var addModel = await _thisRepository.GetByIdAsync(model.Id);
            return addModel.Adapt<SysMenuDto>();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> ModifyAsync(SysMenuDto model)
        {
            model.ParentIdList.RemoveAt(model.ParentIdList.Count - 1);
            if (model.ParentIdList.Count > 0 && model.ParentIdList.All(m => m != "0"))
            {
                model.ParentId = long.Parse(model.ParentIdList.Last());
                model.ParentIdList.Add(model.Id.ToString());
            }
            else
            {
                model.ParentIdList = new List<string> { model.Id.ToString() };
            }

            return await _thisRepository.UpdateAsync(model.Adapt<SysMenu>());
        }

        /// <summary>
        /// 拖动节点排序
        /// </summary>
        /// <returns></returns>
        public async Task ModifyDraggingAsync(SysMenuDropDto model)
        {
            var dragging = await _thisRepository.GetByIdAsync(model.DraggingNode.Id);
            var drop = await _thisRepository.GetByIdAsync(model.DropNode.Id);
            //向上
            if (model.DropType is "before" or "after" && model.DraggingNode.ParentId == model.DropNode.ParentId)
            {
                //同级上下处理
                drop.ParentIdList.RemoveAt(drop.ParentIdList.Count - 1);
                dragging.ParentIdList = drop.ParentIdList;
                dragging.ParentIdList.Add(dragging.Id.ToString());
                dragging.ParentId = drop.ParentId;

                (dragging.Sort, drop.Sort) = (drop.Sort, dragging.Sort);
                await _thisRepository.UpdateRangeAsync(new[] { dragging, drop });
            }
            switch (model.DropType)
            {
                case "before" or "after" when model.DraggingNode.ParentId != model.DropNode.ParentId:
                    //同级内，向下级或上级处理
                    drop.ParentIdList.RemoveAt(drop.ParentIdList.Count - 1);
                    dragging.ParentIdList = drop.ParentIdList;
                    dragging.ParentIdList.Add(dragging.Id.ToString());
                    dragging.ParentId = drop.ParentId;

                    await _thisRepository.UpdateAsync(dragging);
                    break;
                case "inner":
                    dragging.ParentIdList = drop.ParentIdList;
                    dragging.ParentIdList.Add(dragging.Id.ToString());
                    dragging.ParentId = drop.Id;
                    await _thisRepository.UpdateAsync(dragging);
                    break;
            }
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

        /// <summary>
        /// 根据登录人ID查询权限菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AuthorityDto>> GetAuthorityAsync()
        {
            var adminRepository = _thisRepository.ChangeRepository<SugarRepository<SysAdmin>>();
            //根据用户查询角色ID
            var adminModel = await adminRepository.GetSingleAsync(m => m.Id == _operatorService.User.Id);
            var roleIds = adminModel.RoleGroup;

            //根据角色查询授权的菜单Id集合
            var authorityRepository = _thisRepository.ChangeRepository<SugarRepository<SysAuthority>>();
            var authorityList = await authorityRepository.GetListAsync(m => roleIds.Contains(m.RoleId.ToString()));
            #region 保存授权api

            var apiList = new List<SysMenuApiUrl>();
            foreach (var item in authorityList)
            {
                apiList.AddRange(item.Api);
            }
            Console.WriteLine("Api长度：" + apiList.Count);
            RedisService.Instance.SetJson(KeyUtils.AUTHORIZZATIONAPI + ":" + adminModel.Id, apiList);
            #endregion
            //查询菜单集合
            var menuIds = authorityList.Select(m => m.MenuId).ToList();

            //根据菜单ID查询菜单详细
            var menuList = await _thisRepository.GetListAsync(m => m.Status && menuIds.Contains(m.Id), m => m.Sort, OrderEnum.Asc);
            var resMenu = new List<AuthorityDto>();
            foreach (var item in menuList.Where(m => m.Layer == 1).OrderBy(m => m.Sort))
            {
                resMenu.Add(new AuthorityDto()
                {
                    path = item.Urls,
                    name = item.Code.ToLower(),
                    component = "Layout",
                    redirect = item.Redirect,
                    meta = new AuthorityMeta()
                    {
                        title = item.Name,
                        icon = item.Icon,
                    },
                    children = RecursiveModule(menuList, item)
                });
            }

            return resMenu;
        }

        private bool isIframe = false;

        /// <summary>
        /// 递归模块列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parentModel"></param>
        /// <returns></returns>
        [NonDynamicMethod]
        private List<AuthorityDto> RecursiveModule(List<SysMenu> source, SysMenu parentModel)
        {
            var result = new List<AuthorityDto>();
            if (!isIframe)
            {
                result.Add(new AuthorityDto()
                {
                    path = "view",
                    name = "IframeView",
                    component = "@/views/other/iframe/view",
                    meta = new AuthorityMeta()
                    {
                        hidden = true,
                        title = "Iframe",
                        icon = "window-line",
                        dynamicNewTab = true
                    }
                });
                isIframe = true;
            }

            foreach (var item in source.Where(m => m.ParentId == parentModel.Id).OrderBy(m => m.Sort))
            {
                var recursiveList = RecursiveModule(source, item);
                result.Add(new AuthorityDto()
                {
                    path = item.Urls,
                    name = item.Code,
                    component = item.VuePath,
                    //alwaysShow= recursiveList.Count>0,
                    meta = new AuthorityMeta()
                    {
                        title = item.Name,
                        icon = item.Icon,
                        noClosable = item.Code == "Workbench"
                    },
                    children = recursiveList
                });
            }

            return result;
        }

        /// <summary>
        /// 根据登录人ID查询权限菜单[SCUI]
        /// </summary>
        /// <returns></returns>
        public async Task<List<AuthorityDto>> GetAuthorityMenuAsync()
        {
            var adminRepository = _thisRepository.ChangeRepository<SugarRepository<SysAdmin>>();
            //根据用户查询角色ID
            var adminModel = await adminRepository.GetSingleAsync(m => m.Id == _operatorService.User.Id);
            var roleIds = adminModel.RoleGroup;

            //根据角色查询授权的菜单Id集合
            var authorityRepository = _thisRepository.ChangeRepository<SugarRepository<SysAuthority>>();
            var authorityList = await authorityRepository.GetListAsync(m => roleIds.Contains(m.RoleId.ToString()));
            #region 保存授权api

            var apiList = new List<SysMenuApiUrl>();
            foreach (var item in authorityList)
            {
                apiList.AddRange(item.Api);
            }
            RedisService.Instance.SetJson(KeyUtils.AUTHORIZZATIONAPI + ":" + adminModel.Id, apiList);
            #endregion
            //查询菜单集合
            var menuIds = authorityList.Select(m => m.MenuId).ToList();

            //根据菜单ID查询菜单详细
            var menuList = await _thisRepository.GetListAsync(m => m.Status && menuIds.Contains(m.Id), m => m.Sort, OrderEnum.Asc);
            var resMenu = new List<AuthorityDto>();
            foreach (var item in menuList.Where(m => m.ParentId == 0).OrderBy(m => m.Sort))
            {
                resMenu.Add(new AuthorityDto()
                {
                    path = item.Urls,
                    name = item.Code.ToLower(),
                    meta = new AuthorityMeta()
                    {
                        title = item.Name,
                        icon = item.Icon,
                        type = item.Types
                    },
                    children = RecursiveModuleSc(menuList, item)
                });
            }

            return resMenu;
        }

        /// <summary>
        /// 递归模块列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parentModel"></param>
        /// <returns></returns>
        [NonDynamicMethod]
        private List<AuthorityDto> RecursiveModuleSc(List<SysMenu> source, SysMenu parentModel)
        {
            var result = new List<AuthorityDto>();
            foreach (var item in source.Where(m => m.ParentId == parentModel.Id).OrderBy(m => m.Sort))
            {
                var recursiveList = RecursiveModuleSc(source, item);
                result.Add(new AuthorityDto()
                {
                    path = item.Urls,
                    name = item.Code,
                    component = item.VuePath,
                    meta = new AuthorityMeta()
                    {
                        title = item.Name,
                        icon = item.Icon,
                        type = item.Types,
                        affix = item.Code == "dashboard"
                    },
                    children = recursiveList
                });
            }

            return result;
        }
    }
}
