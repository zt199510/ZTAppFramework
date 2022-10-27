using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/22 16:42:46 
    /// Description   ：  个人信息菜单
    ///********************************************/
    /// </summary>
    public class PersonalInfoMenuModel:BindableBase
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Page;
        public string Page
        {
            get { return _Page; }
            set { SetProperty(ref _Page, value); }
        }

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }
    }
}
