using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZTAppFramework.Template.Control
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/22 14:37:55 
    /// Description   ：  RadioButton控件
    ///********************************************/
    /// </summary>
    public class ZTRadioButton: RadioButton
    {
        #region RadioButtonStyle
        public Enums.RadioButtonStyle RadioButtonStyle
        {
            get { return (Enums.RadioButtonStyle)GetValue(RadioButtonStyleProperty); }
            set { SetValue(RadioButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadioButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadioButtonStyleProperty =
            DependencyProperty.Register("RadioButtonStyle", typeof(Enums.RadioButtonStyle), typeof(ZTRadioButton), new PropertyMetadata(Enums.RadioButtonStyle.Standard));
        #endregion

        #region CheckedBackground
        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(ZTRadioButton));

        #endregion

        #region GlyphBrush

        public Brush GlyphBrush
        {
            get { return (Brush)GetValue(GlyphBrushProperty); }
            set { SetValue(GlyphBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GlyphBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlyphBrushProperty =
            DependencyProperty.Register("GlyphBrush", typeof(Brush), typeof(ZTRadioButton));

        #endregion

        #region CheckedGlyphBrush
        public Brush CheckedGlyphBrush
        {
            get { return (Brush)GetValue(CheckedGlyphBrushProperty); }
            set { SetValue(CheckedGlyphBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedGlyphBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedGlyphBrushProperty =
            DependencyProperty.Register("CheckedGlyphBrush", typeof(Brush), typeof(ZTRadioButton));
        #endregion

        #region BoxHeight


        public double BoxHeight
        {
            get { return (double)GetValue(BoxHeightProperty); }
            set { SetValue(BoxHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoxHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoxHeightProperty =
            DependencyProperty.Register("BoxHeight", typeof(double), typeof(ZTRadioButton));


        #endregion

        #region BoxWidth


        public double BoxWidth
        {
            get { return (double)GetValue(BoxWidthProperty); }
            set { SetValue(BoxWidthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for BoxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoxWidthProperty =
            DependencyProperty.Register("BoxWidth", typeof(double), typeof(ZTRadioButton));


        #endregion

        #region CornerRadius


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZTRadioButton));
        #endregion

        #region CheckedContent

        public object CheckedContent
        {
            get { return (object)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.Register("CheckedContent", typeof(object), typeof(ZTRadioButton));
        #endregion

        #region Header
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(ZTRadioButton));


        #endregion

        #region HeaderWidth
        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(string), typeof(ZTRadioButton));


        #endregion

    }
}
