using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZTAppFramework.Template.Enums;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/23 9:32:34 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    internal class ZTMessageControl : ContentControl
    {
        internal ZTMessageControl()
        {
            Loaded += ZTMessageControl_Loaded;
        }

        private async void ZTMessageControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Parent is ZTMessageHost host)
            {
                await Task.Delay(TimeSpan.FromSeconds(Time));
                host.Items.Remove(this);
            }
        }

        public double Time { get; set; }

        [Bindable(true)]
        public MessageStyle Type
        {
            get { return (MessageStyle)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(MessageStyle), typeof(ZTMessageControl), new PropertyMetadata(MessageStyle.Success));
    }
}
