using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using ZTAppFramework.Admin.Model.Device;
using ZTAppFramework.Application.Service;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    /// <summary>
    /// 工作台页面
    /// </summary>
    public class WorkbenchViewModel : NavigationViewModel
    {
        #region UI
        private DateTime _CurrentTime;//当前时间

        public DateTime CurrentTime
        {
            get { return _CurrentTime; }
            set { SetProperty(ref _CurrentTime, value); }
        }

        private DeviceUseModel _DeviceUseModel;
        public DeviceUseModel DeviceUseModel
        {
            get { return _DeviceUseModel; }
            set { SetProperty(ref _DeviceUseModel, value); }
        }

        private List<MachineInfoModel> _Machines;

        public List<MachineInfoModel> Machines
        {
            get { return _Machines; }
            set { SetProperty(ref _Machines, value); }
        }
        #endregion

        #region Command

        #endregion

        #region Service
        private readonly WorkbenchService _workbenchService;
        #endregion

        #region 属性
        DispatcherTimer Timer = new DispatcherTimer();

        #endregion

        public WorkbenchViewModel(WorkbenchService workbenchService)
        {
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick; ;
            _workbenchService = workbenchService;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;

            UpdateDeviceInfo();
        }

        async void UpdateDeviceInfo()
        {
            var r = await _workbenchService.GetMachineUse();
            if (r.Success)
            {
                DeviceUseModel = Map<DeviceUseModel>(r.data);
            }
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Timer.Stop();
        }

        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            Timer.Start();
            CurrentTime = DateTime.Now;
            UpdateDeviceInfo();
            var r = await _workbenchService.GetMachineInfo();
            if (r.Success)
                Machines = Map<List<MachineInfoModel>>(r.data);
        }
    }
}
