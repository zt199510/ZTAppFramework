using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFramework.Application.Service;
using ZTAppFreamework.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class UserCenterViewModel : NavigationViewModel
    {

        #region UI
        private OperatorWorkModel _OperatorWorkModel;
        public OperatorWorkModel OperatorWorkModel
        {
            get { return _OperatorWorkModel; }
            set { SetProperty(ref _OperatorWorkModel, value); }
        }

        private List<PersonalInfoMenuModel> _BasicInfoMenu;

        public List<PersonalInfoMenuModel> BasicInfoMenu
        {
            get { return _BasicInfoMenu; }
            set { SetProperty(ref _BasicInfoMenu, value); }
        }

        private List<PersonalInfoMenuModel> _DataMangerMenu;

        public List<PersonalInfoMenuModel> DataMangerMenu
        {
            get { return _DataMangerMenu; }
            set { SetProperty(ref _DataMangerMenu, value); }
        }

        #endregion

        #region Command
        public DelegateCommand<PersonalInfoMenuModel> GoPageCommand { get; }
        #endregion

        #region Serivce
        private readonly OperatorService _operatorService;
        private readonly IRegionManager _regionManager;
     
        #endregion
        public UserCenterViewModel(OperatorService operatorService, IRegionManager regionManager)
        {
            _operatorService = operatorService;
            _regionManager = regionManager;
        
            BasicInfoMenu = new List<PersonalInfoMenuModel>()
            {
                new PersonalInfoMenuModel(){Name="账号信息",Page=AppView.PersonalInfoName},
                new PersonalInfoMenuModel(){Name="个人设置",Page=AppView.UserPerferfabName},
                new PersonalInfoMenuModel(){Name="修改密码",Page=AppView.UserEditPasswordName},
                new PersonalInfoMenuModel(){Name="通知设置",Page=AppView.UserNoticSettingsName}
            };
            DataMangerMenu = new List<PersonalInfoMenuModel>()
            {
                new PersonalInfoMenuModel(){Name="存储空间信息",Page=AppView.PersonalInfoName},
                new PersonalInfoMenuModel(){Name="操作日志",Page=AppView.PersonalInfoName}
            };
          

            GoPageCommand = new DelegateCommand<PersonalInfoMenuModel>(GoPage);
        }

        private void GoPage(PersonalInfoMenuModel Parm)
        {
            Parm.IsSelected = true;
       
            if (Parm.Page==AppView.PersonalInfoName)
            {
                NavigationParameters NavPgaeParm = new NavigationParameters();
                NavPgaeParm.Add("OperatorWorkModel", OperatorWorkModel);
                _regionManager.Regions[AppView.UserCenterMnagerName].RequestNavigate(Parm.Page, NavPgaeParm);
              
            }
            else
            {
                _regionManager.Regions[AppView.UserCenterMnagerName].RequestNavigate(Parm.Page);
                return;
            }
          
        }


        #region override

        public override bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public override async Task OnNavigatedToAsync(NavigationContext navigationContext = null)
        {
            var r = await _operatorService.GetUserWordInfo();
            if (r.Success)
            {
                OperatorWorkModel = Map<OperatorWorkModel>(r.data);      
                GoPage(BasicInfoMenu.First());
            }

        }
        #endregion

    }
}
