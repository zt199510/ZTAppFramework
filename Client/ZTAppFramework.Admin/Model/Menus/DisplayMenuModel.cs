using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Menus
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/22 11:27:13 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class DisplayMenuModel:BindableBase
    {
        private string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set { SetProperty(ref _MenuName, value); }
        }

        private string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { SetProperty(ref _PageName, value); }
        }
    }
}
