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
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/15 9:09:36 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public interface IZTDialogResult
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        ButtonResult Result { get; }
        ZTDialogParameter Parameters { get; }
    }
}
