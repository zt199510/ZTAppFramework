using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using ZTAppFramework.Template.Enums;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/21 9:19:34 
    /// Description   ：  进度条控件
    ///********************************************/
    /// </summary>
    public class ZTProgressBar:ProgressBar
    {

        #region ProgressBarStyle
        public ProgressBarStyle ProgressBarStyle
        {
            get { return (ProgressBarStyle)GetValue(ProgressBarStyleProperty); }
            set { SetValue(ProgressBarStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressBarStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBarStyleProperty =
            DependencyProperty.Register("ProgressBarStyle", typeof(ProgressBarStyle), typeof(ZTProgressBar), new PropertyMetadata(Enums.ProgressBarStyle.Standard));
        #endregion

        #region CornerRadius    
   

        public double ZTCornerRadius
        {
            get { return (double)GetValue(ZTCornerRadiusProperty); }
            set { SetValue(ZTCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZTCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZTCornerRadiusProperty =
            DependencyProperty.Register("ZTCornerRadius", typeof(double), typeof(ZTProgressBar));


        #endregion

        #region BodreBrush



        public Brush ProgressBrush
        {
            get { return (Brush)GetValue(ProgressBrushProperty); }
            set { SetValue(ProgressBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBrushProperty =
            DependencyProperty.Register("ProgressBrush", typeof(Brush), typeof(ZTProgressBar));




        #endregion

        #region AnimateTo
        /// <summary>
        /// 动画开始
        /// </summary>
        public double AnimateTo
        {
            get { return (double)GetValue(AnimateToProperty); }
            set { SetValue(AnimateToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimateTo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimateToProperty =
            DependencyProperty.Register("AnimateTo", typeof(double), typeof(ZTProgressBar), new PropertyMetadata(OnAnimateToChanged));

        private static void OnAnimateToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var value = Math.Round((double)e.NewValue) ;
            var progressBar = d as ZTProgressBar;
            var anima = new DoubleAnimation()
            {
                To = value,
                Duration = progressBar.AnimationDuration,
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
            };
            progressBar.BeginAnimation(ProgressBar.ValueProperty, anima);
        }

        #endregion

        #region AnimationDuration

        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimationDuration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationDurationProperty =
           DependencyProperty.RegisterAttached("AnimationDuration", typeof(TimeSpan), typeof(ZTProgressBar), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));

        #endregion

        #region IsPercentVisible



        public bool IsPercentVisible
        {
            get { return (bool)GetValue(IsPercentVisibleProperty); }
            set { SetValue(IsPercentVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPercentVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPercentVisibleProperty =
            DependencyProperty.Register("IsPercentVisible", typeof(bool), typeof(ZTProgressBar));
        #endregion
    }
}
