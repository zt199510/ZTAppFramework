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
    /// 创建时间    ：  2022/9/15 9:23:27 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public interface IZTDialogAware
    {

        event Action<IZTDialogResult> RequestClose;
        void OnDialogOpened(IZTDialogParameter parameters);
    }
}
