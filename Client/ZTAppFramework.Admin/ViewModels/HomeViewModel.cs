using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Menus;
using ZTAppFramework.Application.Service;
using ZTAppFreamework.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class HomeViewModel : NavigationViewModel
    {
        private readonly MenuService _menuService;
        public IRegionManager _RegionManager { get; set; }
        public NavigationService NavigationService { get; set; }

        #region UI
        private DisplayMenuModel _DisplayMenus;
        public DisplayMenuModel DisplayMenus
        {
            get { return _DisplayMenus; }
            set { SetProperty(ref _DisplayMenus, value); }
        }



        private List<MenuModel> _MenuList;
        public List<MenuModel> MenuList
        {
            get { return _MenuList; }
            set { SetProperty(ref _MenuList, value); }
        }
        private List<MenuModel> _PageList;
        public List<MenuModel> PageList
        {
            get { return _PageList; }
            set { SetProperty(ref _PageList, value); }
        }

        private MenuModel _SelectMenu;
        public MenuModel SelectMenu
        {
            get { return _SelectMenu; }
            set
            {
                if (SetProperty(ref _SelectMenu, value))
                {
                    PageList = value.Childer;
                    PageList.ForEach(x =>
                    {
                        if (SelectPage != null)
                            if (x.name == SelectPage.name)
                                x.IsSelected = true;
                            else
                                x.IsSelected = false;

                    });
                }

            }
        }

        private MenuModel _SelectPage;
        public MenuModel SelectPage
        {
            get { return _SelectPage; }
            set
            {
                if (SetProperty(ref _SelectPage, value))
                {
                    switch (value.name)
                    {
                        case "个人信息":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.UserCenterName); break;
                        case "工作台":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.WorkbenchName); break;
                        case "机构管理":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.OrganizeName); break;
                        case "角色管理":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.RoleName); break;
                        case "职位管理":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.SysPostName); break;
                        case "用户管理":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.SysAdminName); break;
                        case "资源管理":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.SysMenuName);break;
                        case "权限设置":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.SysAuthorizeName); break;
                        case "系统日志":
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.SysLogsName); break;
                        default:
                            _RegionManager?.Regions[AppView.HomeName]?.RequestNavigate(AppView.UserPerferfabName); break;
                      
                    }
                    if (DisplayMenus == null)
                        DisplayMenus = new DisplayMenuModel();

                    DisplayMenus.MenuName = SelectMenu.name;
                    DisplayMenus.PageName = SelectPage.name;
                }
            }
        }
        #endregion

        #region Command

        public DelegateCommand<MenuModel> GoMenuCommand { get; set; }
        public DelegateCommand<MenuModel> GoPageCommand { get; set; }
        #endregion
        public HomeViewModel(MenuService menuService, IRegionManager regionManager)
        {
            _menuService = menuService;
            _RegionManager = regionManager;
            GoPageCommand = new DelegateCommand<MenuModel>(GoPage);
            GoMenuCommand = new DelegateCommand<MenuModel>(Gomenu);
        }

        private void Gomenu(MenuModel Parm)
        {
            SelectMenu = Parm;// MenuList.First().Childer.First();
            SelectMenu.IsSelected = true;
        }

        private void GoPage(MenuModel Parm)
        {
           
            SelectPage = Parm;// MenuList.First().Childer.First();
            SelectPage.IsSelected = true;

        }

        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            var Ar = await _menuService.GetMenuList();
            if (Ar.Success)
            {
                MenuList = Map<List<MenuModel>>(Ar.data);
                SelectMenu = MenuList.First();
                SelectPage = MenuList.First().Childer.First();
                MenuList.First().IsSelected = true;
                SelectPage.IsSelected = true;

            }


        }
    }
}
