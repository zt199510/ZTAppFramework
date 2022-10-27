using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using ZTAppFramework.Template.Global;

namespace ZTAppFramework.Template.Control
{
    public class ZTMultiComboBox : System.Windows.Controls.Primitives.MultiSelector
    {

        #region 标识符
        private PropertyInfo _displayMemberPropertyInfo;

        private FrameworkElement _lblIcon;
        #endregion

        #region Constructor 构造函数
        static ZTMultiComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZTMultiComboBox), new FrameworkPropertyMetadata(typeof(ZTMultiComboBox)));

        }
        #endregion
        public virtual string GenerateText(IList selectedItems)
        {
            var text = "";
            var isFirst = true;

            foreach (var item in selectedItems)
            {
                if (!isFirst)
                    text += TextSeparator;
                else
                    isFirst = false;

                if (item is ZTMultiComboBoxItem)
                {
                    var msi = item as ZTMultiComboBoxItem;
                    text += msi.Content.ToString();
                }
                else
                {
                    if (_displayMemberPropertyInfo == null || _displayMemberPropertyInfo.Name != DisplayMemberPath)
                        _displayMemberPropertyInfo = item.GetType().GetProperty(DisplayMemberPath);

                    text += _displayMemberPropertyInfo.GetValue(item, null).ToString();
                }

                if (MaxTextLength == null)
                {
                    if (!ValidateStringWidth(text + ExceededTextFiller))
                    {
                        if (text.Length == 0)
                            return null;
                        text = text.Remove(text.Length - 1);
                        while (!ValidateStringWidth(text + ExceededTextFiller))
                        {
                            if (text.Length == 0)
                                return null;
                            text = text.Remove(text.Length - 1);
                        }
                        return text + ExceededTextFiller;
                    }
                }
                else if (text.Length >= MaxTextLength)
                {
                    return text.Cut((int)MaxTextLength, ExceededTextFiller);
                }
            }
            return text;
        }

        #region 属性

        [Bindable(true)]
        public IList MultiSelectedItems
        {
            get { return (IList)GetValue(MultiSelectedItemsProperty); }
            set { SetValue(MultiSelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MultiSelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MultiSelectedItemsProperty =
            DependencyProperty.Register("MultiSelectedItems", typeof(IList), typeof(ZTMultiComboBox), new PropertyMetadata(Chanagerlist));

        private static void Chanagerlist(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = (ZTMultiComboBox)d;
            if (comboBox.MultiSelectedItems == null) return;
            comboBox.BeginUpdateSelectedItems();
            for (int i = 0; i < comboBox.MultiSelectedItems.Count; i++)
                comboBox.SelectedItems.Add(comboBox.MultiSelectedItems[i]);
            comboBox.EndUpdateSelectedItems();
        }

        public Brush HoverBorderBrush
        {
            get { return (Brush)GetValue(HoverBorderBrushProperty); }
            set { SetValue(HoverBorderBrushProperty, value); }
        }


        // Using a DependencyProperty as the backing store for HoverBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(ZTMultiComboBox));


        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(ZTMultiComboBox));

        public double MaxDropDownHeight
        {
            get { return (double)GetValue(MaxDropDownHeightProperty); }
            set { SetValue(MaxDropDownHeightProperty, value); }
        }
        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(ZTMultiComboBox));

        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }
        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(ZTMultiComboBox));
        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(ZTMultiComboBox));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ZTMultiComboBox));

        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }
        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(ZTMultiComboBox));

        public string TextSeparator
        {
            get { return (string)GetValue(TextSeparatorProperty); }
            set { SetValue(TextSeparatorProperty, value); }
        }

        public static readonly DependencyProperty TextSeparatorProperty =
            DependencyProperty.Register("TextSeparator", typeof(string), typeof(ZTMultiComboBox), new PropertyMetadata(","));



        public int? MaxTextLength
        {
            get { return (int?)GetValue(MaxTextLengthProperty); }
            set { SetValue(MaxTextLengthProperty, value); }
        }

        public static readonly DependencyProperty MaxTextLengthProperty =
            DependencyProperty.Register("MaxTextLength", typeof(int?), typeof(ZTMultiComboBox));

        public string ExceededTextFiller
        {
            get { return (string)GetValue(ExceededTextFillerProperty); }
            set { SetValue(ExceededTextFillerProperty, value); }
        }

        public static readonly DependencyProperty ExceededTextFillerProperty =
            DependencyProperty.Register("ExceededTextFiller", typeof(string), typeof(ZTMultiComboBox), new PropertyMetadata("..."));

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(ZTMultiComboBox));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZTMultiComboBox));

        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(ZTMultiComboBox));

        public Thickness ItemPadding
        {
            get { return (Thickness)GetValue(ItemPaddingProperty); }
            set { SetValue(ItemPaddingProperty, value); }
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.Register("ItemPadding", typeof(Thickness), typeof(ZTMultiComboBox));

        public bool IsSearchTextBoxVisible
        {
            get { return (bool)GetValue(IsSearchTextBoxVisibleProperty); }
            set { SetValue(IsSearchTextBoxVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSearchTextBoxVisibleProperty =
            DependencyProperty.Register("IsSearchTextBoxVisible", typeof(bool), typeof(ZTMultiComboBox));


        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(ZTMultiComboBox), new PropertyMetadata(OnSearchTextChanged));

        public string SearchTextBoxWatermark
        {
            get { return (string)GetValue(SearchTextBoxWatermarkProperty); }
            set { SetValue(SearchTextBoxWatermarkProperty, value); }
        }

        public static readonly DependencyProperty SearchTextBoxWatermarkProperty =
            DependencyProperty.Register("SearchTextBoxWatermark", typeof(string), typeof(ZTMultiComboBox));


        #endregion
        public ZTMultiComboBox()
        {
            Loaded -= MultiComboBox_Loaded;
            Loaded += MultiComboBox_Loaded;
            SizeChanged -= MultiComboBox_SizeChanged;
            SizeChanged += MultiComboBox_SizeChanged;

        }

        #region Event
        public static readonly RoutedEvent SearchTextChangedEvent = EventManager.RegisterRoutedEvent("SearchTextChanged", RoutingStrategy.Bubble, typeof(SearchTextChangedEventHandler), typeof(ZTMultiComboBox));
        public event SearchTextChangedEventHandler SearchTextChanged
        {
            add { AddHandler(SearchTextChangedEvent, value); }
            remove { RemoveHandler(SearchTextChangedEvent, value); }
        }
        void RaiseSearchTextChanged(string newValue)
        {
            var arg = new SearchTextChangedEventArgs(newValue, SearchTextChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region EventHandler
        private static void OnSearchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as ZTMultiComboBox;
            selector.RaiseSearchTextChanged(e.NewValue as string);
        }

        private void MultiComboBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            UpdateText();
        }
        private void MultiComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateText();
        }
        #endregion

        #region Function



        private void UpdateText()
        {
            Text = GenerateText(SelectedItems);
        }

        private bool ValidateStringWidth(string text)
        {
            if (_lblIcon == null)
            {
                _lblIcon = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1), 0) as FrameworkElement;
            }
            var size = MeasureString(text);
            if (size.Width > (ActualWidth - Padding.Left - Padding.Right - 30 - _lblIcon?.ActualWidth))
                return false;
            else
                return true;

        }

        private Size MeasureString(string candidate)
        {
            var formattedText = new FormattedText(candidate, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, Brushes.Black, new NumberSubstitution(), TextFormattingMode.Display);

            return new Size(formattedText.Width, formattedText.Height);
        }


        #endregion

        #region Override
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ZTMultiComboBoxItem();
        }


        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;
            if (MultiSelectedItems != null)
            {
                //添加用户选中的当前项.
                foreach (var item in e.AddedItems)
                {
                    if (!MultiSelectedItems.Contains(item))
                        MultiSelectedItems.Add(item);
                }
                //删除用户取消选中的当前项
                foreach (var item in e.RemovedItems)
                {
                    if (MultiSelectedItems.Contains(item))
                        MultiSelectedItems.Remove(item);
                }
            }
            UpdateText();
            base.OnSelectionChanged(e);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            if (item is ZTMultiComboBoxItem)
                return true;
            else
                return false;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var uie = element as FrameworkElement;

            if (!(item is ZTMultiComboBoxItem))
            {
                var textBinding = new Binding(DisplayMemberPath);
                textBinding.Source = item;
                uie.SetBinding(ContentPresenter.ContentProperty, textBinding);
            }

            base.PrepareContainerForItemOverride(element, item);
        }

        #endregion
    }
}
