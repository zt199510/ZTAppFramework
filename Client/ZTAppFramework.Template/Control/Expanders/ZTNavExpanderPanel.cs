using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/6 14:55:35 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class ZTNavExpanderPanel: StackPanel
    {

        public bool IsAutoFold
        {
            get { return (bool)GetValue(IsAutoFoldProperty); }
            set { SetValue(IsAutoFoldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAutoFold.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAutoFoldProperty =
            DependencyProperty.Register("IsAutoFold", typeof(bool), typeof(ZTNavExpanderPanel), new PropertyMetadata(false));
    }
}
