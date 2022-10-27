using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZTAppFramework.Template.Global;

namespace ZTAppFramework.Admin.Dialog
{
    /// <summary>
    /// DialogWindowBase.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindowBase : Window,IZTDialogWindow
    {
        public DialogWindowBase()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += DialogWindowBase_MouseLeftButtonDown;
        }

        private void DialogWindowBase_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        public IZTDialogResult Result { get ; set ; }
    }
}
