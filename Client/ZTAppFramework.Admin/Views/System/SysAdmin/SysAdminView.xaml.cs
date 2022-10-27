using System.Windows.Controls;

namespace ZTAppFramework.Admin.Views
{
    /// <summary>
    /// Interaction logic for SysAdminView
    /// </summary>
    public partial class SysAdminView : UserControl
    {
        public SysAdminView()
        {
            InitializeComponent();
            
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;

        }
    }
}
