using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Template.Enums;

namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/15 9:25:36 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class ZTDialogResult : IZTDialogResult
    {
        public ButtonResult Result { get; set; } = ButtonResult.None;

        public ZTDialogParameter Parameters { get; set; }
    }
}
