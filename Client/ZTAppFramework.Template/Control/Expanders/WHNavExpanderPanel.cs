using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/10/17 14:17:28 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class WHNavExpanderPanel : StackPanel
    {
        public bool IsAutoFold
        {
            get { return (bool)GetValue(IsAutoFoldProperty); }
            set { SetValue(IsAutoFoldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAutoFold.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAutoFoldProperty =
            DependencyProperty.Register("IsAutoFold", typeof(bool), typeof(WHNavExpanderPanel), new PropertyMetadata(false));
    }
}
