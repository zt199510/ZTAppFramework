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
    public class SysPostViewModel : NavigationViewModel
    {
        #region UI
        private List<SysPostModel> _SysPostList;
        public List<SysPostModel> SysPostList
        {
            get { return _SysPostList; }
            set { SetProperty(ref _SysPostList, value); }
        }

        private List<SysPostModel> _SelectList = new List<SysPostModel>();
        public List<SysPostModel> SelectList
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

        public DelegateCommand<SysPostModel> ModifCommand { get; }

        public DelegateCommand<SysPostModel> DeleteSeifCommand { get; }

        public DelegateCommand<SysPostModel> CheckedCommand { get; }

        public DelegateCommand<SysPostModel> UncheckedCommand { get; }


        #endregion

        #region Service
        private readonly SysPostService _sysPostService;
        #endregion


        public SysPostViewModel(SysPostService  sysPostService)
        {
            _sysPostService = sysPostService;
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
                await GetListInfo(QueryStr);
            });

        }

        void UnCheckedAll()
        {
            foreach (var item in SysPostList)
            {
                item.IsSelected = false;
                SelectList.Remove(item);
            }
        }
        void CheckedAll()
        {
            foreach (var item in SysPostList)
            {

                item.IsSelected = true;
                SelectList.Add(item);
            }
        }
        void Unchecked(SysPostModel Param) => SelectList.Remove(Param);
        void Checked(SysPostModel Param) => SelectList.Add(Param);
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
                    string DelIdStr = string.Join(',', SelectList.Select(X => X.Id));
                    var r = await _sysPostService.Delete(DelIdStr);
                    if (r.Success)
                    {
                        Show("消息", "删除成功!");
                        await GetListInfo();
                        return;
                    }
                }
            }, System.Windows.MessageBoxButton.YesNo);
        }
        void Modif(SysPostModel Param)
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "编辑");
            dialogParameter.Add("Param", Param);
            ZTDialog.ShowDialogWindow(AppView.SysPostModifyName, dialogParameter, async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {
                    await GetListInfo();
                }
            });
        }
        void DeleteSeif(SysPostModel Param)
        {
            ShowDialog("提示", "确定要删除码", async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {
                    var r = await _sysPostService.Delete(Param.Id.ToString());
                    if (r.Success)
                    {
                        Show("消息", "删除成功!");
                        await GetListInfo();
                        return;
                    }
                }
            }, System.Windows.MessageBoxButton.YesNo);
        }
        void Add()
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "添加");
            ZTDialog.ShowDialogWindow(AppView.SysPostModifyName, dialogParameter, async x =>
            {
                if (x.Result == ZTAppFramework.Template.Enums.ButtonResult.Yes)
                {

                    await GetListInfo();
                }
            });
        }

        async Task GetListInfo(string Query = "")
        {
            var r = await _sysPostService.GetPostList(new ZTAppFramewrok.Application.Stared.PageParam() {Key= Query==""?null:Query });
            if (r.Success)
            {
                SysPostList = Map<List<SysPostModel>>(r.data.Items).OrderBy(X => X.Sort).ToList();
            }
                
            SelectList.Clear();
        }
        #endregion

        #region Override
        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            await GetListInfo();
        }


        #endregion
    }
}
