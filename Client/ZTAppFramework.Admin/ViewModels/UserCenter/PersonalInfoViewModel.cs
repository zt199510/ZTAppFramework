using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFramework.Application.Service;
using ZTAppFramewrok.Application.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    /// <summary>
    /// 个人信息界面
    /// </summary>
    public class PersonalInfoViewModel : NavigationViewModel
    {
        #region UI
        private OperatorWorkModel _OperatorWorkModel;
        public OperatorWorkModel OperatorWorkModel
        {
            get { return _OperatorWorkModel; }
            set { SetProperty(ref _OperatorWorkModel, value); }
        }



        #endregion

        #region Command

        public DelegateCommand SavePersionInfoCommand { get; }
        #endregion

        #region Service
        private readonly AdminService _adminService;
        #endregion

        public PersonalInfoViewModel(AdminService adminService)
        {
            _adminService = adminService;

            SavePersionInfoCommand = new DelegateCommand(SavePersionInfo);
        }

        #region Event

        /// <summary>
        /// 保存个人信息
        /// </summary>
        private async void SavePersionInfo()
        {
            await SetBusyAsync(async () => {

                await Task.Delay(300);
                var r = await _adminService.MoifBasic(Map<OperatorWordDto>(OperatorWorkModel));
                if (r.Success)
                {
                    ZTMessage.Success(r.Message, "RootMessageTooken");
                }
                else
                {
                    ShowDialog("消息", r.Message,null);
                   // ZTMessage.Error(r.Message, "RootMessageTooken");
                }  
            });
        }
        #endregion

   

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public override Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            OperatorWorkModel = navigationContext.Parameters["OperatorWorkModel"] as OperatorWorkModel;
            return Task.CompletedTask;
        }
    }
}
