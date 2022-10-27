using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ZTAppFramework.Template.Animations
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/22 10:24:45 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class GridLengthAniamtion : AnimationTimeline
    {

        public static readonly DependencyProperty FromProperty;
        public static readonly DependencyProperty ToProperty;
        public static readonly DependencyProperty EasingFunctionProperty;


        static GridLengthAniamtion()
        {
            FromProperty = DependencyProperty.Register("From", typeof(GridLength), typeof(GridLengthAniamtion));
            ToProperty = DependencyProperty.Register("To", typeof(GridLength), typeof(GridLengthAniamtion));
            EasingFunctionProperty = DependencyProperty.Register("EasingFunction", typeof(IEasingFunction), typeof(GridLengthAniamtion));
        }

        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAniamtion();
        }

        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }


        public IEasingFunction EasingFunction
        {
            get
            {
                return (IEasingFunction)GetValue(EasingFunctionProperty);
            }
            set
            {
                SetValue(EasingFunctionProperty, value);
            }

        }

        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(FromProperty);
            }
            set
            {
                SetValue(FromProperty, value);
            }
        }

        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(ToProperty);
            }
            set
            {
                SetValue(ToProperty, value);
            }
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            double fromValue = ((GridLength)GetValue(FromProperty)).Value;
            double toValue = ((GridLength)GetValue(ToProperty)).Value;

            IEasingFunction easingFunction = EasingFunction;

            double progress = easingFunction != null ? easingFunction.Ease(animationClock.CurrentProgress.Value) : animationClock.CurrentProgress.Value;

            if (fromValue > toValue)
            {
                return new GridLength((1 - progress) * (fromValue - toValue) + toValue, To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
            else
            {
                return new GridLength(progress * (toValue - fromValue) + fromValue, To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
        }
    }
}
