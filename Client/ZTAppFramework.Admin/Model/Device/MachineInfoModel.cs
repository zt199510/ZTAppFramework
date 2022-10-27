using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Device
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/21 13:44:45 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class MachineInfoModel : BindableBase
    {

        private string _Key;
        public string Key
        {
            get { return _Key; }
            set { SetProperty(ref _Key, value); }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }


    }
}
