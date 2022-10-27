using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/15 9:27:47 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class ZTDialogUserControlWindow : ContentControl, IZTDialogUserControlWindow
    {
        public IZTDialogResult Result { get; set; }
    }
}
