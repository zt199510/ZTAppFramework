using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ZTAppFramework.Template.Extensions;

namespace ZTAppFramework.Template.Converters
{
    internal class MultiComboBoxIsCheckedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var item = values[0];
            var selectedMemberPath = values[1] as string;
            if (item == null || selectedMemberPath.IsNullOrEmpty())
                return false;

            var propertyInfo = item.GetType().GetProperty(selectedMemberPath);
            if (propertyInfo == null || propertyInfo.PropertyType != typeof(bool))
                return false;

            return propertyInfo.GetValue(item, null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
