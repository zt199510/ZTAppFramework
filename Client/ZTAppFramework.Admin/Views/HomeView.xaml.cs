using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using ZTAppFramework.Template.Control;
using ZTAppFramework.Template.Animations;

namespace ZTAppFramework.Admin.Views
{
    /// <summary>
    /// Interaction logic for Home
    /// </summary>
    public partial class HomeView : UserControl
    {


        public HomeView()
        {
            InitializeComponent();
            IsCheckBoxVis.IsChecked = true;
        }

        private void ZTCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GridLengthAniamtion d = new GridLengthAniamtion();
            d.From = new GridLength(60, GridUnitType.Pixel);
            d.To = new GridLength(120, GridUnitType.Pixel);
            d.Duration = TimeSpan.FromSeconds(0.2);
            PageGridLine.BeginAnimation(ColumnDefinition.WidthProperty, d);
            Grid.SetRow(PageGrid, 1);
            Grid.SetRowSpan(PageGrid, 1);
        }

        private void ZTCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GridLengthAniamtion d = new GridLengthAniamtion();
            d.From = new GridLength(120, GridUnitType.Pixel);
            d.To = new GridLength(60, GridUnitType.Pixel);
            d.Duration = TimeSpan.FromSeconds(0.2);
            PageGridLine.BeginAnimation(ColumnDefinition.WidthProperty, d);
            Grid.SetRow(PageGrid, 0);
            Grid.SetRowSpan(PageGrid, 2);
 
        }
    }
}
