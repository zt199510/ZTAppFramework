using Prism.Services.Dialogs;
using System;
using System.Printing;
using System.Windows;

namespace ZTAppFramework.Admin.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, IDialogWindow
    {
        public LoginView()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) =>
            {
                if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    try
                    {
                         this.DragMove();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            };

            this.BackBtn.Click += (s, e) => { Environment.Exit(0); };
            
        }



        public IDialogResult Result { get; set; }
    }
}
