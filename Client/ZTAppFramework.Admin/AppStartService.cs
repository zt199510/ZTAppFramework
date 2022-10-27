using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZTAppFreamework.Stared.Service;
using ZTAppFreamework.Stared;
using Prism.Regions;
using System.Windows.Threading;

namespace ZTAppFramework.Admin
{

    /// <summary>
    /// 应用关系管理
    /// </summary>
    public class AppStartService
    {
        System.Windows.Application app;
        public void Exit()
        {
            Environment.Exit(0);
        }

        public async Task<Window> CreateShell(System.Windows.Application application)
        {
            this.app = application;
            //UI线程未捕获异常处理事件
            app.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            //UI线程未捕获异常处理事件
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //Task线程内未捕获异常处理事件
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;

            var container = ContainerLocator.Container;
            if (!Authorization()) ExitApplication();
            var shell = container.Resolve<object>(AppView.MainName);
            if (shell is Window view)
            {
                var regionManager = container.Resolve<IRegionManager>();
                RegionManager.SetRegionManager(view, regionManager);
                RegionManager.UpdateRegions();
                regionManager.Regions[AppView.MainName].RequestNavigate(AppView.HomeName);
                if (view.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(null);
                    return (Window)shell;
                }
            }
            return null;
        }

 
        public static bool Authorization()
        {
            var dialogService = ContainerLocator.Container.Resolve<IHostDialogService>();
            return dialogService.ShowWindow(AppView.LoginName).Result == Prism.Services.Dialogs.ButtonResult.OK;
            //  return false;
        }
        public static void ExitApplication() => Environment.Exit(0);

        #region ExceptionHanding

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();//设置该异常已察觉（这样处理后就不会引起程序崩溃）
        }


        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                e.Handled = true; //把 Handled 属性设为true，表示此异常已处理，程序可以继续运行，不会强制退出
            }
            catch (Exception ex)
            {
                //此时程序出现严重异常，将强制结束退出
                MessageBox.Show("UI线程发生致命错误！" + ex.Message);
            }
        }

        #endregion


    }
}
