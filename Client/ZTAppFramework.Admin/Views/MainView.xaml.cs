using System;
using System.Windows;
using ZTAppFramework.Template.Control;

namespace ZTAppFramework.Admin.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ZTWindow
    {
        public MainView()
        {
            InitializeComponent();

            this.BackBtn.Click += (s, e) => { Environment.Exit(0); };
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}
