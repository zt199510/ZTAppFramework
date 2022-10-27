using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace ZTAppFramework.Template.Converters
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/10/18 15:51:15 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class RunStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Transparent);
            if (value == null) return brush;

            string st = value.ToString();
            if (st == "空闲")
                brush = new SolidColorBrush(Colors.LightGreen);
            else if (st == "运行")
                brush = new SolidColorBrush(Colors.Green);
            else if (st == "急停")
                brush = new SolidColorBrush(Colors.Red);
            else if (st == "暂停")
                brush = new SolidColorBrush(Colors.Orange);

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }


    #region 轴状态专颜色
    public class AxisStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Transparent);
            if (value == null) return brush;
            bool s = System.Convert.ToBoolean(value);
            if (s)
                brush = new SolidColorBrush(Colors.Red);
            else
                brush = new SolidColorBrush(Colors.LightGreen);
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    #endregion

    #region 轴状态转字符串


    public class AxisStatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "未知";
            bool s = System.Convert.ToBoolean(value);
            if (s)
                return "运行";
            else
                return "空闲";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    #endregion


    #region 物料
    public class CalibrationToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "未知";
            int type = int.Parse(value.ToString());//标定单位，0:mll,1:mm,2cm
            if (type == 0) return "mll";
            else if (type == 1) return "mm";
            else if (type == 2) return "cm";
            else
                return "未知";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class CompanyTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "未知";
            int type = int.Parse(value.ToString());//第1个点标定类型0：圆，1：长方形，2椭圆，10：其他
            if (type == 0) return "圆";
            else if (type == 1) return "长方形";
            else if (type == 2) return "椭圆";
            else if (type == 10) return "其他";
            else
                return "未知";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    #endregion
}
