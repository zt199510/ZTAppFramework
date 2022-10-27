using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/15 9:32:12 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    internal static class IZTDialogUserControlWindowExtensions
    {
        internal static IZTDialogAware GetDialogViewModel(this IZTDialogUserControlWindow dialog)
        {
            return (IZTDialogAware)dialog.DataContext;
        }
    }
}
