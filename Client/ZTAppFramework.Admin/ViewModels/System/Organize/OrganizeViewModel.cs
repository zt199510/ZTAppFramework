using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Application.Service;
using ZTAppFreamework.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{

    /// <summary>
    /// 组织页面VM
    /// </summary>
    public class OrganizeViewModel : NavigationViewModel
    {
        #region UI
        private List<SysOrganizeModel> _OrganizesList;
        public List<SysOrganizeModel> OrganizesList
        {
            get { return _OrganizesList; }
            set { SetProperty(ref _OrganizesList, value); }
        }

        private List<SysOrganizeModel> _SelectList = new List<SysOrganizeModel>();
        public List<SysOrganizeModel> SelectList
        {
            get { return _SelectList; }
            set { SetProperty(ref _SelectList, value); }
        }

        private string _QueryStr;

        public string QueryStr
        {
            get { return _QueryStr; }
            set { SetProperty(ref _QueryStr, value); }
        }
        #endregion

        #region Command
        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteSelectCommand { get; }
        public DelegateCommand CheckedAllCommand { get; }
        public DelegateCommand UnCheckedAllCommand { get; }

        public DelegateCommand QueryCommand { get; }

        public DelegateCommand<SysOrganizeModel> ModifCommand { get; }

        public DelegateCommand<SysOrganizeModel> DeleteSeifCommand { get; }

        public DelegateCommand<SysOrganizeModel> CheckedCommand { get; }

        public DelegateCommand<SysOrganizeModel> UncheckedCommand { get; }


        #endregion

        #region Service
        private readonly OrganizeService _organizeService;
        #endregion

        public OrganizeViewModel(OrganizeService organizeService)
        {
            _organizeService = organizeService;
            AddCommand = new(Add);
            ModifCommand = new(Modif);
            DeleteSeifCommand = new(DeleteSeif);
            DeleteSelectCommand = new(DeleteSelect);
            CheckedCommand = new(Checked);
            UncheckedCommand = new(Unchecked);
            CheckedAllCommand = new(CheckedAll);
            UnCheckedAllCommand = new(UnCheckedAll);
            QueryCommand = new(Query);
        }

        #region Event
        private async void Query()
        {
            await SetBusyAsync(async () =>
            {
                await GetOrganizeInfo(QueryStr);
            });

        }

        void UnCheckedAll()
        {
            foreach (var item in OrganizesList)
            {
                item.IsSelected = false;
                SelectList.Remove(item);
            }
        }
        void CheckedAll()
        {
            foreach (var item in OrganizesList)
            {

                item.IsSelected = true;
                SelectList.Add(item);
            }
        }
        void Unchecked(SysOrganizeModel Param) => SelectList.Remove(Param);
        void Checked(SysOrganizeModel Param) => SelectList.Add(Param);
        void DeleteSelect()
        {
            if (SelectList.Count <= 0)
            {
                Show("消息", "请选择要删除得数据");
                return;
            }
            ShowDialog("提示", $"确定要删除{SelectList.Count()}个数据吗？如果删除项中含有子集将会被一并删除", async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {
                    List<string> strings = new List<string>();
                    foreach (var item in SelectList)
                    {
                        var rd = OrganizesList.Where(x => x.ParentIdList.Contains(item.Id.ToString()));
                        if (rd != null)
                        {
                            foreach (var Panentitem in rd)
                            {
                                strings.Add(Panentitem.Id.ToString());
                            }
                        }
                          
                        strings.Add(item.Id.ToString());
                    }
                    string DelIdStr = string.Join(',', strings);
                    var r = await _organizeService.Delete(DelIdStr);
                    if (r.Success)
                    {
                        Show("消息", "删除成功!");
                        await GetOrganizeInfo();
                        return;
                    }
                }
            }, System.Windows.MessageBoxButton.YesNo);
        }
        void Modif(SysOrganizeModel Param)
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "编辑");
            dialogParameter.Add("Param", Param);
            ZTDialog.ShowDialogWindow(AppView.OrganizeModifyName, dialogParameter, async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {
                    await GetOrganizeInfo();
                }
            });
        }
        void DeleteSeif(SysOrganizeModel Param)
        {
            ShowDialog("提示", "确定要删除码", async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {

                    List<string> strings = new List<string>();
                    var rd = OrganizesList.Where(x => x.ParentIdList.Contains(Param.Id.ToString()));
                    if (rd != null)
                    {
                        foreach (var item in rd)
                            strings.Add(item.Id.ToString());
                    }
                    strings.Add(Param.Id.ToString());
                    string DelIdStr = string.Join(',', strings);
                    var r = await _organizeService.Delete(DelIdStr);
                    if (r.Success)
                    {
                        Show("消息", "删除成功!");
                        await GetOrganizeInfo();
                        return;
                    }
                }
            }, System.Windows.MessageBoxButton.YesNo);
        }
        void Add()
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "添加");
            ZTDialog.ShowDialogWindow(AppView.OrganizeModifyName, dialogParameter, async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {

                    await GetOrganizeInfo();
                }
            });
        }
        async Task GetOrganizeInfo(string Query = "")
        {
            var r = await _organizeService.GetList(Query);
            if (r.Success)
                OrganizesList = Map<List<SysOrganizeModel>>(r.data).OrderBy(X => X.Sort).ToList();
            SelectList.Clear();
        }

        #endregion

        #region Override
        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            await GetOrganizeInfo();
        }


        #endregion

    }
}
