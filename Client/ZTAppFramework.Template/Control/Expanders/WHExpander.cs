using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/10/17 14:17:08 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class WHExpander : HeaderedContentControl
    {

        /// <summary>
        /// 监听状态
        /// </summary>
        private ToggleButton headerToggleButton = null;

        public VerticalAlignment HeaderVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(HeaderVerticalAlignmentProperty); }
            set { SetValue(HeaderVerticalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderVerticalAlignmentProperty =
            DependencyProperty.Register("HeaderVerticalAlignment", typeof(VerticalAlignment), typeof(WHExpander));


        public HorizontalAlignment HeaderHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(HeaderHorizontalAlignmentProperty); }
            set { SetValue(HeaderHorizontalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderHorizontalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderHorizontalAlignmentProperty =
            DependencyProperty.Register("HeaderHorizontalAlignment", typeof(HorizontalAlignment), typeof(WHExpander));




        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(WHExpander), new PropertyMetadata(IsIsExpandedChanage));

        private static void IsIsExpandedChanage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }






        /// <summary>
        /// 顶部高度
        /// </summary>
        public double HeaderHeight
        {
            get { return (double)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeaderHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(double), typeof(WHExpander));



        /// <summary>
        /// 顶部颜色
        /// </summary>
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeaderBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(WHExpander));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (headerToggleButton != null)
            {
                headerToggleButton = GetTemplateChild("header") as ToggleButton;
                headerToggleButton.Checked -= HeaderToggleButton_Click;
                headerToggleButton.Checked += HeaderToggleButton_Click;
            }
        }

        private void HeaderToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshExpanded();
        }

        /// <summary>
        /// 刷新折叠效果
        /// </summary>
        private void RefreshExpanded()
        {
            if (this.Parent == null) return;
            if (this.Parent is WHNavExpanderPanel panel)
            {
                if (!panel.IsAutoFold) return;
                foreach (var item in panel.Children)
                {
                    if (item is WHExpander expander && expander != this)
                    {
                        expander.IsExpanded = false;
                    }
                }
            }
        }
    }
}
