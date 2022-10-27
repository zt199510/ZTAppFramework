using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;

namespace ZTAppFramework.Admin.Model.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/10/9 11:00:37 
    /// Description   ：  日志模型
    ///********************************************/
    /// </summary>
    public class SysLogMenuModel: BindableBase
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }


        private List<SysLogMenuModel> _Childer;
        public List<SysLogMenuModel> Childer
        {
            get { return _Childer; }
            set { SetProperty(ref _Childer, value); }
        }
    }
}
