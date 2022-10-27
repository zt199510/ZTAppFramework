using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Application.Service;

using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class SysMenuViewModel : NavigationViewModel
    {
        #region UI
        private ObservableCollection<SysMenuModel> _MenuTreeList;
        public ObservableCollection<SysMenuModel> MenuTreeList
        {
            get { return _MenuTreeList; }
            set { SetProperty(ref _MenuTreeList, value); }
        }

        private SysMenuModel _SelectedItems;

        public SysMenuModel SelectedItems
        {
            get { return _SelectedItems; }
            set
            {
                SetProperty(ref _SelectedItems, value);
            }
        }

        private SysMenuModel _Info;
        public SysMenuModel Info
        {
            get { return _Info; }
            set { SetProperty(ref _Info, value); }
        }
        #endregion

        #region Command
        public DelegateCommand<SysMenuModel> CheckedCommand { get; }

        public DelegateCommand<SysMenuModel> GoMenuInfoCommand { get; }
        #endregion

        #region Serviec
        private readonly MenuService _SysMenuSerVice;
        private readonly SysMenuService _sysMenuService;
        #endregion
        public SysMenuViewModel(MenuService SysMenuSerVice, SysMenuService sysMenuService)
        {
            _SysMenuSerVice = SysMenuSerVice;
            _sysMenuService = sysMenuService;
            CheckedCommand = new DelegateCommand<SysMenuModel>(ExcuteChecked);
            GoMenuInfoCommand = new DelegateCommand<SysMenuModel>(GoMenuInfo);
        }






        #region Event

        private void GoMenuInfo(SysMenuModel Param)
        {
            SelectedItems = Param;
            GetMenuInfo();

        }

        async void GetMenuInfo()
        {
            var r = await _sysMenuService.Query(SelectedItems.Id.ToString());
            if (r.Success)
            {
                Info = Map<SysMenuModel>(r.data);
            }
        }


        async Task GetMenuTreeInfo()
        {
            var r = await _SysMenuSerVice.GetMenuList();
            if (r.Success)
            {
                MenuTreeList = Map<ObservableCollection<SysMenuModel>>(r.data);
            }
        }

        #region TreeViewEvent
        private void ExcuteChecked(SysMenuModel Param)
        {
            CheckPrent(MenuTreeList, Param);
            CheckItems(Param.Childer, Param);
        }


        /// <summary>
        /// 设置父类选中状态
        /// </summary>
        /// <param name="apps">需要设置的集合</param>
        /// <param name="info">被操纵对象</param>
        private void CheckPrent(ObservableCollection<SysMenuModel> apps, SysMenuModel info)
        {
            OnCheckPrent(apps, info);
            UnCheckPrent(apps, info);
        }
        /// <summary>
        /// 递归刷新全选和反选状态效果
        /// </summary>
        /// <param name="apps">需要设置的集合</param>
        /// <param name="info">被操纵对象</param>
        void CheckItems(ObservableCollection<SysMenuModel> apps, SysMenuModel info)
        {
            if (apps == null) return;
            foreach (var item in apps)
            {
                item.IsChecked = info.IsChecked;
                CheckItems(item.Childer, info);
            }
        }

        /// <summary>
        /// 设置父类选中状态
        /// </summary>
        /// <param name="apps">需要设置的集合</param>
        /// <param name="info">被操纵对象</param>
        void OnCheckPrent(ObservableCollection<SysMenuModel> apps, SysMenuModel info)
        {
            foreach (var item in apps)
            {
                if (item.Id == info.ParentId)
                {
                    if (info.IsChecked)
                    {
                        item.IsChecked = true;
                        if (item.ParentId == 0) return;
                        OnCheckPrent(MenuTreeList, item);
                    }
                }
                else
                {
                    if (item.Childer == null) return;
                    OnCheckPrent(item.Childer, info);
                }
            }
        }

        /// <summary>
        ///设置父类取消选中状态
        /// </summary>
        /// <param name="apps">需要设置的集合</param>
        /// <param name="info">被操纵对象</param>
        void UnCheckPrent(ObservableCollection<SysMenuModel> apps, SysMenuModel info)
        {
            foreach (var item in apps)
            {
                if (item.Id == info.ParentId)
                {
                    if (!info.IsChecked)
                    {
                        /////////////设置抓取复选框///////////
                        var unCheckNum = item.Childer.ToList().Where(o => o.IsChecked == false).Count();
                        if (unCheckNum == item.Childer.Count) item.IsChecked = false;
                        if (item.ParentId == 0) return;
                        UnCheckPrent(MenuTreeList, item);
                    }
                }
                else
                {
                    if (item.Childer == null) return;
                    UnCheckPrent(item.Childer, info);
                }
            }
        }
        /// <summary>
        /// 初始化加载刷新集合列表选中状态
        /// </summary>
        /// <param name="apps">需要设置的集合</param>
        /// <param name="info">被操纵对象</param>
        void RefreshItemsIsChecked(ObservableCollection<SysMenuModel> apps, SysMenuModel info)
        {
            if (apps == null) return;
            foreach (var item in apps)
            {
                if (item.Id == info.Id)
                {
                    item.IsChecked = true;
                }
                else
                {
                    RefreshItemsIsChecked(item.Childer, info);
                }
            }
        }
        #endregion


        #endregion


        #region Override

        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            await GetMenuTreeInfo();
            SelectedItems = MenuTreeList.First();
            SelectedItems.IsSelected = true;
        }
        #endregion


    }
}
