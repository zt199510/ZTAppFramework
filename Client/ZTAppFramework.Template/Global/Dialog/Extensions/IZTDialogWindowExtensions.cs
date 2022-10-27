using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/15 9:22:39 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    internal static class IZTDialogWindowExtensions
    {
        internal static IZTDialogWindowAware GetDialogViewModel(this IZTDialogWindow dialog)
        {
            return (IZTDialogWindowAware)dialog.DataContext;
        }
    }
}
