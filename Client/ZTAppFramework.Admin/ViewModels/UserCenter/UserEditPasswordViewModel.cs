using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFramework.Application.Service;
using ZTAppFramewrok.Application.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class UserEditPasswordViewModel : NavigationViewModel
    {

        #region UI
        private UserEditPwdModel _userEditPwd;


        public UserEditPwdModel UserEditPwd
        {
            get { return _userEditPwd; }
            set { SetProperty(ref _userEditPwd, value); }
        }
        #endregion

        #region Command

        public DelegateCommand ModifPasswordCommand { get; }
        #endregion

        #region Service
        private readonly OperatorService _OperatorService;
        #endregion


        public UserEditPasswordViewModel(OperatorService operatorService)
        {

            _OperatorService = operatorService;
            UserEditPwd = new UserEditPwdModel();

            ModifPasswordCommand = new DelegateCommand(ModifPassword);
        }

        private async void ModifPassword()
        {
           /// if (!Verify(UserEditPwd).IsValid) return;
            var r = await _OperatorService.EditPassword(Map<OperatroPasswordParam>(UserEditPwd));
            if (r.Success)
            {
                ZTMessage.Success(r.Message, "RootMessageTooken");
              
                UserEditPwd.VerifyNewPassword = UserEditPwd.NewPassword = UserEditPwd.CurrnetPassword = "";
                return;
            }
            else
            {
                ShowDialog("修改密码", r.Message);
            }
        }
    }
}
