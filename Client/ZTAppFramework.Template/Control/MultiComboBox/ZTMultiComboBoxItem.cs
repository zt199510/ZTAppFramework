using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTAppFramework.Template.Control
{
    public class ZTMultiComboBoxItem : ListBoxItem
    {
        static ZTMultiComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZTMultiComboBoxItem), new FrameworkPropertyMetadata(typeof(ZTMultiComboBoxItem)));
        }

        #region Event 

        #endregion

        #region Property
        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(ZTMultiComboBoxItem));


        #endregion
    }
}
