using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    /// 加载动画
    /// </summary>
    public class ZTLoading:ContentControl
    {

        /// <summary>
        /// 动画开关
        /// </summary>
        [Bindable(true)]
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(ZTLoading), new PropertyMetadata(false));

        /// <summary>
        /// 提示信息
        /// </summary>
        [Bindable(true)]
        public object MessageContent
        {
            get { return (object)GetValue(MessageContentProperty); }
            set { SetValue(MessageContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageContentProperty =
            DependencyProperty.Register("MessageContent", typeof(object), typeof(ZTLoading));


        [Bindable(true)]
        public Enums.LoadingStyle Type
        {
            get { return (Enums.LoadingStyle)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Enums.LoadingStyle), typeof(ZTLoading), new PropertyMetadata(Enums.LoadingStyle.Google));

    }
}
