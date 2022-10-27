using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ZTAppFramework.Template.Enums;

namespace ZTAppFramework.Template.Control
{
    public class ZTButton:Button
    {
        public object LoadingContent
        {
            get { return (object)GetValue(LoadingContentProperty); }
            set { SetValue(LoadingContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadingContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingContentProperty =
            DependencyProperty.Register("LoadingContent", typeof(object), typeof(ZTButton));


        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(ZTButton), new PropertyMetadata(false));


        /// <summary>
        /// 按钮圆角
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZTButton));

        /// <summary>
        /// 按钮类型
        /// </summary>
        public ButtonStyle Type
        {
            get { return (ButtonStyle)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(ButtonStyle), typeof(ZTButton), new PropertyMetadata(ButtonStyle.Default));




        public ButtonType ButtonType
        {
            get { return (ButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.Register("ButtonType", typeof(ButtonType), typeof(ZTButton), new PropertyMetadata(ButtonType.Standard));




        public bool IsAnimantion
        {
            get { return (bool)GetValue(IsAnimantionProperty); }
            set { SetValue(IsAnimantionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAnimantion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnimantionProperty =
            DependencyProperty.Register("IsAnimantion", typeof(bool), typeof(ZTButton), new PropertyMetadata(true));



        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(ZTButton), new PropertyMetadata(Brushes.Transparent));


        public Brush HoverBorderBrush
        {
            get { return (Brush)GetValue(HoverBorderBrushProperty); }
            set { SetValue(HoverBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(ZTButton), new PropertyMetadata(Brushes.Transparent));


    }
}
