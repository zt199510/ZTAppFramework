using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/21 14:45:44 
    /// Description   ：  Windows样式
    ///********************************************/
    /// </summary>
    public class ZTWindow: Window
    {
        /// <summary>
        /// 设置重写默认样式
        /// </summary>
        static ZTWindow()
        {
            ;
            StyleProperty.OverrideMetadata(typeof(ZTWindow), new FrameworkPropertyMetadata(Application.Current.FindResource(nameof(ZTWindow) + "Style")));
        }
        /// <summary>
        /// 动画类型
        /// </summary>
        [Bindable(true)]
        public Enums.AnimationType Type
        {
            get { return (Enums.AnimationType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Enums.AnimationType), typeof(ZTWindow), new PropertyMetadata(Enums.AnimationType.Default));
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
