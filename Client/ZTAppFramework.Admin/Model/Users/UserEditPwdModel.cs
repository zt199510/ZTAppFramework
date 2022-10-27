using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.Model.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/23 15:20:39 
    /// Description   ：  修改密码
    ///********************************************/
    /// </summary>
    public class UserEditPwdModel: PropertyViewModel
    {
        public UserEditPwdModel()
        {
            _CurrnetPassword = "";
            _NewPassword = "";
            _VerifyNewPassword = "";
        }
        private string _CurrnetPassword;
        public string CurrnetPassword
        {
            get { return _CurrnetPassword; }
            set { _CurrnetPassword = value; RaisePropertyChanged("CurrnetPassword"); }
        }

        private string _NewPassword;


        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; RaisePropertyChanged("NewPassword"); }
        }

        private string _VerifyNewPassword;

        public string VerifyNewPassword
        {
            get { return _VerifyNewPassword; }
            set { _VerifyNewPassword = value; RaisePropertyChanged("VerifyNewPassword"); }
        }

        public override string this[string columnName] { get => VerifyTostring(this, columnName); }
    }
}
