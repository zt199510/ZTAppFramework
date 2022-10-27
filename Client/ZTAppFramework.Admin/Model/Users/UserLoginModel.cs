using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ZTAppFramework.Admin.Validations.Users;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.Model.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/3 17:20:00 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class UserLoginModel : PropertyViewModel
    {
        private string _UserName;//用户

        private string _Password;//密码

        public UserLoginModel()
        {
            UserName = "";
            Password = "";
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; RaisePropertyChanged("UserName"); }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; RaisePropertyChanged("Password"); }
        }

        /// <summary>
        /// 验证码
        /// </summary>
        private string _Code;

        public string Code
        {
            get { return _Code; }
            set { _Code = value;RaisePropertyChanged(); }
        }
        /// <summary>
        /// 验证码Key
        /// </summary>

        private string _CodeKey="12312312";

        public string CodeKey
        {
            get { return _CodeKey; }
            set { _CodeKey = value;RaisePropertyChanged(); }
        }


        public override string this[string columnName] { get => VerifyTostring(this,columnName); }
    }
}
