using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTAppFramework.Template.Control 
{ 
    /// <summary>
    /// 表格控件
    /// </summary>
    public class ZTDataGrid:DataGrid
    {

        /// <summary>
        /// 记录行刷新状态 用于行刷新
        /// </summary>
        bool isRefresh = false;

        #region DataGridStyle

        public Enums.DataGridStyle DataGridStyle
        {
            get { return (Enums.DataGridStyle)GetValue(DataGridStyleProperty); }
            set { SetValue(DataGridStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataGridStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataGridStyleProperty =
            DependencyProperty.Register("DataGridStyle", typeof(Enums.DataGridStyle), typeof(ZTDataGrid), new PropertyMetadata(Enums.DataGridStyle.Standard));


        #endregion

        #region ElementCheckBoxColumnStyle
        [Bindable(true)]
        public Style ElementCheckBoxColumnStyle
        {
            get { return (Style)GetValue(ElementCheckBoxColumnStyleProperty); }
            set { SetValue(ElementCheckBoxColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingComboBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementCheckBoxColumnStyleProperty =
            DependencyProperty.Register("ElementCheckBoxColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnCheckBoxColumnStyleChanged));


        #endregion

        #region EditingCheckBoxColumnStyle

        [Bindable(true)]
        public Style EditingCheckBoxColumnStyle
        {
            get { return (Style)GetValue(EditingCheckBoxColumnStyleProperty); }
            set { SetValue(EditingCheckBoxColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingCheckBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditingCheckBoxColumnStyleProperty =
            DependencyProperty.Register("EditingCheckBoxColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnCheckBoxColumnStyleChanged));
        #endregion

        #region ElementComboBoxColumnStyle
        [Bindable(true)]
        public Style ElementComboBoxColumnStyle
        {
            get { return (Style)GetValue(ElementComboBoxColumnStyleProperty); }
            set { SetValue(ElementComboBoxColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ElementComboBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementComboBoxColumnStyleProperty =
            DependencyProperty.Register("ElementComboBoxColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnComboBoxColumnStyleChanged));


        #endregion

        #region EditingComboBoxColumnStyle

        [Bindable(true)]
        public Style EditingComboBoxColumnStyle
        {
            get { return (Style)GetValue(EditingComboBoxColumnStyleProperty); }
            set { SetValue(EditingComboBoxColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingComboBoxColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditingComboBoxColumnStyleProperty =
            DependencyProperty.Register("EditingComboBoxColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnComboBoxColumnStyleChanged));
        #endregion

        #region ElementTextColumnStyle
        [Bindable(true)]
        public Style ElementTextColumnStyle
        {
            get { return (Style)GetValue(ElementTextColumnStyleProperty); }
            set { SetValue(ElementTextColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ElementTextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementTextColumnStyleProperty =
            DependencyProperty.Register("ElementTextColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnTextColumnStyleChanged));


        #endregion

        #region EditingTextColumnStyle
        [Bindable(true)]
        public Style EditingTextColumnStyle
        {
            get { return (Style)GetValue(EditingTextColumnStyleProperty); }
            set { SetValue(EditingTextColumnStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingTextColumnStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditingTextColumnStyleProperty =
            DependencyProperty.Register("EditingTextColumnStyle", typeof(Style), typeof(ZTDataGrid), new PropertyMetadata(default(Style), OnTextColumnStyleChanged));
        #endregion

        #region IsShowRowsFocusVisual

        [Bindable(true)]
        public bool IsShowRowsFocusVisual
        {
            get { return (bool)GetValue(IsShowRowsFocusVisualProperty); }
            set { SetValue(IsShowRowsFocusVisualProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowRowsFocusVisual.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowRowsFocusVisualProperty =
            DependencyProperty.Register("IsShowRowsFocusVisual", typeof(bool), typeof(ZTDataGrid), new PropertyMetadata(false));
        #endregion

        #region NoDataTips
        /// <summary>
        /// 无数据提示信息
        /// </summary>
        [Bindable(true)]
        public string NoDataTips
        {
            get { return (string)GetValue(NoDataTipsProperty); }
            set { SetValue(NoDataTipsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NoDataTips.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoDataTipsProperty =
            DependencyProperty.Register("NoDataTips", typeof(string), typeof(ZTDataGrid), new PropertyMetadata("暂无数据"));
        #endregion

        #region IsActive动画开关
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
            DependencyProperty.Register("IsActive", typeof(bool), typeof(ZTDataGrid), new PropertyMetadata(false));
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateTextColumnStyles(this);
            UpdateComboBoxColumnStyles(this);
            UpdateCheckBoxColumnStyles(this);
        }

        /// <summary>
        /// 监听行变化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if (e.Action != NotifyCollectionChangedAction.Add)
            {
                //防止当前视图出现递归刷新
                if (!isRefresh)
                {
                    isRefresh = true;
                    /////////重新渲染视图/////////
                    this.Items.Refresh();
                    isRefresh = false;
                }
            }
        }
        protected override void OnLoadingRow(DataGridRowEventArgs e)
        {
            base.OnLoadingRow(e);
            SetLineNumber(e.Row, e.Row.GetIndex() + 1);
        }
        /// <summary>
        /// 获得列表当前行号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetLineNumber(DependencyObject obj)
        {
            return (int)obj.GetValue(LineNumberProperty);
        }
        /// <summary>
        /// 设置列表当前行号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void SetLineNumber(DependencyObject obj, int value)
        {
            obj.SetValue(LineNumberProperty, value);
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineNumberProperty =
            DependencyProperty.RegisterAttached("LineNumber", typeof(int), typeof(ZTDataGrid));

        #region Event
        private static void OnCheckBoxColumnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ZTDataGrid ztDataGrid)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    ztDataGrid.UpdateCheckBoxColumnStyles(ztDataGrid);
                }
            }
        }

        /// <summary>
        /// 更新复选框样式
        /// </summary>
        /// <param name="layDataGrid"></param>
        private void UpdateCheckBoxColumnStyles(ZTDataGrid ztDataGrid)
        {
            var checkBoxColumnStyle = ElementCheckBoxColumnStyle;
            var editingCheckBoxColumnStyle = EditingCheckBoxColumnStyle;

            if (checkBoxColumnStyle != null)
            {
                foreach (var column in ztDataGrid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var elementStyle = new Style
                    {
                        BasedOn = column.ElementStyle,
                        TargetType = checkBoxColumnStyle.TargetType
                    };

                    foreach (var setter in checkBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        elementStyle.Setters.Add(setter);
                    }

                    column.ElementStyle = elementStyle;
                }
            }

            if (editingCheckBoxColumnStyle != null)
            {
                foreach (var column in ztDataGrid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var editingElementStyle = new Style
                    {
                        BasedOn = column.EditingElementStyle,
                        TargetType = editingCheckBoxColumnStyle.TargetType
                    };

                    foreach (var setter in editingCheckBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        editingElementStyle.Setters.Add(setter);
                    }

                    column.EditingElementStyle = editingElementStyle;
                }
            }
        }

        private static void OnComboBoxColumnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ZTDataGrid ztDataGrid)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    ztDataGrid.UpdateComboBoxColumnStyles(ztDataGrid);
                }
            }
        }

        /// <summary>
        /// 更新下拉框样式
        /// </summary>
        /// <param name="layDataGrid"></param>
        private void UpdateComboBoxColumnStyles(ZTDataGrid ztDataGrid)
        {
            var comboBoxColumnStyle = ElementComboBoxColumnStyle;
            var editingComboBoxColumnStyle = EditingComboBoxColumnStyle;

            if (comboBoxColumnStyle != null)
            {
                foreach (var column in ztDataGrid.Columns.OfType<DataGridComboBoxColumn>())
                {
                    var elementStyle = new Style
                    {
                        BasedOn = column.ElementStyle,
                        TargetType = comboBoxColumnStyle.TargetType
                    };

                    foreach (var setter in comboBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        elementStyle.Setters.Add(setter);
                    }

                    column.ElementStyle = elementStyle;
                }
            }

            if (editingComboBoxColumnStyle != null)
            {
                foreach (var column in ztDataGrid.Columns.OfType<DataGridComboBoxColumn>())
                {
                    var editingElementStyle = new Style
                    {
                        BasedOn = column.EditingElementStyle,
                        TargetType = editingComboBoxColumnStyle.TargetType
                    };

                    foreach (var setter in editingComboBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        editingElementStyle.Setters.Add(setter);
                    }

                    column.EditingElementStyle = editingElementStyle;
                }
            }
        }

        private static void OnTextColumnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ZTDataGrid ztDataGrid)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    ztDataGrid.UpdateTextColumnStyles(ztDataGrid);
                }
            }
        }

        /// <summary>
        /// 更新文本样式
        /// </summary>
        /// <param name="grid"></param>
        private void UpdateTextColumnStyles(ZTDataGrid grid)
        {
            var textColumnStyle = ElementTextColumnStyle;
            var editingTextColumnStyle = EditingTextColumnStyle;
            if (textColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridTextColumn>())
                {
                    var elementStyle = new Style
                    {
                        BasedOn = column.ElementStyle,
                        TargetType = textColumnStyle.TargetType
                    };

                    foreach (var setter in textColumnStyle.Setters.OfType<Setter>())
                    {
                        elementStyle.Setters.Add(setter);
                    }

                    column.ElementStyle = elementStyle;
                }
            }
            if (editingTextColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridTextColumn>())
                {
                    var editingElementStyle = new Style
                    {
                        BasedOn = column.EditingElementStyle,
                        TargetType = editingTextColumnStyle.TargetType,
                    };

                    foreach (var setter in editingTextColumnStyle.Setters.OfType<Setter>())
                    {
                        editingElementStyle.Setters.Add(setter);
                    }

                    column.EditingElementStyle = editingElementStyle;
                }
            }
        }
        #endregion

    }
}
