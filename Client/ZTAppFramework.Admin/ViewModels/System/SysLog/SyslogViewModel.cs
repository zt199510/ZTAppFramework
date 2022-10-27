using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Application.Service;
using ZTAppFramewrok.Application.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class SyslogViewModel : NavigationViewModel
    {
        #region Ui
        private List<SysLogMenuModel> _MenuList;


        public List<SysLogMenuModel> MenuList
        {
            get { return _MenuList; }
            set { SetProperty(ref _MenuList, value); }
        }

        private List<SysLogModel>  _SysLogList;

        public List<SysLogModel> SysLogList
        {
            get { return  _SysLogList; }
            set { SetProperty(ref  _SysLogList, value); }
        }
        #endregion

        #region Command
        public DelegateCommand CheckedAllCommand { get; }
        public DelegateCommand UnCheckedAllCommand { get; }
        public DelegateCommand CheckedCommand { get; }
        public DelegateCommand UncheckedCommand { get; }
        #endregion

        #region Service
        private readonly SysLogSerivce _SysLogSerivce;
        #endregion

        #region 属性

        #endregion
        public SyslogViewModel(SysLogSerivce sysLogSerivce)
        {
            _SysLogSerivce = sysLogSerivce;
            MenuList = new List<SysLogMenuModel>();
            CheckedAllCommand = new DelegateCommand(CheckedAll);
            UnCheckedAllCommand = new DelegateCommand(UnChecked);
            CreateMenu();
        }

        #region CommandEvenet

        void CheckedAll()
        {

        }

        void UnChecked()
        {

        }

        #endregion

        #region Event
        void CreateMenu()
        {
            MenuList.Add(new SysLogMenuModel()
            {
                Name = "日志级别",
                Childer = new List<SysLogMenuModel>()
                {
                    new SysLogMenuModel(){  Name="Debug"} ,
                    new SysLogMenuModel(){  Name="Info"} ,
                    new SysLogMenuModel(){  Name="Warn"} ,
                    new SysLogMenuModel(){  Name="Error"} ,
                    new SysLogMenuModel(){  Name="Fatal"} ,
                }
            });

            MenuList.Add(new SysLogMenuModel()
            {
                Name = "日志类型",
                Childer = new List<SysLogMenuModel>()
                {
                  new SysLogMenuModel(){  Name="登入日志"} ,
                  new SysLogMenuModel(){  Name="操作日志"} ,
                }

            });
        }

        async Task GetLogInfo()
        {
            var r = await _SysLogSerivce.GetPostList(new PageParam() { Page=0,Limit=20});
            if (r.Success)
            {
                SysLogList = Map<List<SysLogModel>>(r.data.Items);
            }
        }
        #endregion


        #region override
        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            await GetLogInfo();
        }
        #endregion

    }
}
