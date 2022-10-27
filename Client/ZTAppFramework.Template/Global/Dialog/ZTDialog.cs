using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using ZTAppFramework.Template.Control;


namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/15 9:02:14 
    /// Description   ：  Dialog 控制器
    ///********************************************/
    /// </summary>
    public class ZTDialog
    {
        public ZTDialog()
        {

        }

        /// <summary>
        /// 被注入的窗体集合
        /// </summary>
        internal static Dictionary<string, Type> DialogViewCollection { get; set; } = DialogViewCollection ?? new Dictionary<string, Type>();
        /// <summary>
        /// 对话框载体
        /// </summary>
        internal static Dictionary<string, Type> DialogWindow { get; set; } = DialogWindow ?? new Dictionary<string, Type>();
        /// <summary>
        /// 对话框组件
        /// </summary>
        internal static Dictionary<string, ZTDialogHost> DialogHosts { get; set; } = DialogHosts ?? new Dictionary<string, ZTDialogHost>();

        #region Tooken



       
        public static string GetDialogTooken(DependencyObject obj)
        {
            return (string)obj.GetValue(DialogTookenProperty);
        }

        public static void SetDialogTooken(DependencyObject obj, string value)
        {
            obj.SetValue(DialogTookenProperty, value);
        }

        // Using a DependencyProperty as the backing store for DialogTooken.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogTookenProperty =
            DependencyProperty.RegisterAttached("DialogTooken", typeof(string), typeof(ZTDialog), new PropertyMetadata(OnTookenChange));


        #endregion
        private static void OnTookenChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ZTDialogHost host = d as ZTDialogHost;
                if (host == null) return;
                var tooken = ZTDialog.GetDialogTooken(host);
                if (!ZTDialog.DialogHosts.ContainsKey(tooken)) ZTDialog.DialogHosts.Add(tooken, host); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


      


        /// Identifies the WindowStyle attached property.
        /// </summary>
        /// <remarks>
        /// This attached property is used to specify the style of a <see cref="IDialogWindow"/>.
        /// </remarks>
        public static readonly DependencyProperty WindowStyleProperty =
            DependencyProperty.RegisterAttached("WindowStyle", typeof(Style), typeof(ZTDialog), new PropertyMetadata(null));

        /// <summary>
        /// Gets the value for the <see cref="WindowStyleProperty"/> attached property.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The <see cref="WindowStyleProperty"/> attached to the <paramref name="obj"/> element.</returns>
        public static Style GetWindowStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(WindowStyleProperty);
        }

        /// <summary>
        /// Sets the <see cref="WindowStyleProperty"/> attached property.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The Style to attach.</param>
        public static void SetWindowStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(WindowStyleProperty, value);
        }


        /// <summary>
        /// 注入对话框窗体载体
        /// </summary>
        /// <typeparam name="TView">需要注入的类型</typeparam>
        /// <param name="dialogName">视图名称</param>
        public static void RegisterDialogWindow<TWindow>(string windowName) where TWindow : IZTDialogWindow
        {
            try
            {
                if (DialogWindow.ContainsKey(windowName)) throw new Exception($"{windowName}对话框窗体载体多次注入");
                DialogWindow.Add(windowName, typeof(TWindow));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 注入弹窗试图
        /// </summary>
        /// <typeparam name="TView">需要注入的类型</typeparam>
        /// <param name="dialogName">视图名称</param>
        public static void RegisterDialog<TView>(string dialogName)
        {
            try
            {
                if (DialogViewCollection.ContainsKey(dialogName)) throw new Exception($"{dialogName}弹窗视图多次注入");
                DialogViewCollection.Add(dialogName, typeof(TView));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        /// <summary>
        /// 普通弹窗
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="tooken">需要通知弹窗的唯一健值</param>
        public static void Show(string dialogName, IZTDialogParameter parameters, string tooken = null) => Alert(dialogName, parameters, null, false, tooken, null);

        /// <summary>
        /// 普通弹窗
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="windowName">指定需要打开的窗体样式</param>
        public static void ShowWindow(string dialogName, IZTDialogParameter parameters, string windowName) => Alert(dialogName, parameters, null, false, null, windowName);
        /// <summary>
        /// 普通弹窗
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="callback">回调</param>
        /// <param name="tooken">需要通知弹窗的唯一健值</param>
        public static void Show(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, string tooken = null) => Alert(dialogName, parameters, callback, false, tooken, null);
        /// <summary>
        /// 普通弹窗
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="callback">回调</param>
        /// <param name="windowName">指定需要打开的窗体样式</param>
        public static void ShowWindow(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, string windowName) => Alert(dialogName, parameters, callback, false, null, windowName);
        /// <summary>
        /// 模态对话框
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="tooken">需要通知弹窗的唯一健值</param>
        public static void ShowDialog(string dialogName, IZTDialogParameter parameters, string tooken = null) => Alert(dialogName, parameters, null, true, tooken, null);
        /// <summary>
        /// 模态对话框
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="windowName">指定需要打开的窗体样式</param>
        public static void ShowDialogWindow(string dialogName, IZTDialogParameter parameters, string windowName = null) => Alert(dialogName, parameters, null, true, null, windowName);
        /// <summary>
        /// <summary>
        /// 模态对话框
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="callback">回调</param>
        /// <param name="tooken">需要通知弹窗的唯一健值,如果是Window窗体该值给Null</param>
        public static void ShowDialog(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, string tooken = null) => Alert(dialogName, parameters, callback, true, tooken, null);
        /// <summary>
        /// <summary>
        /// 模态对话框
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="callback">回调</param>
        /// <param name="windowName">指定需要打开的窗体样式</param>
        public static void ShowDialogWindow(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, string windowName = null) => Alert(dialogName, parameters, callback, true, null, windowName);

        /// <summary>
        /// 弹窗业务
        /// </summary>
        /// <param name="dialogName">窗体名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="callback">回调</param>
        /// <param name="isModel">是否为模态</param>
        /// <param name="tooken">需要通知弹窗的唯一健值,如果是Window窗体该值给Null</param>
        /// <param name="windowName">指定需要打开的窗体样式</param>
        private static void Alert(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, bool isModel, string tooken, string windowName)
        {
            if (windowName != null) AlertWindow(dialogName, parameters, callback, isModel, windowName);
            else AlertUserControl(dialogName, parameters, callback, isModel, tooken);
        }

        /// <summary>
        /// 弹起Window窗体
        /// </summary>
        /// <param name="dialogName"></param>
        /// <param name="parameters"></param>
        /// <param name="callback"></param>
        /// <param name="isModel"></param>
        /// <param name="tooken"></param>
        /// <param name="windowName"></param>
        private static void AlertWindow(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, bool isModel, string windowName)
        {
            try
            {
                IZTDialogWindow window = Activator.CreateInstance(DialogWindow[windowName]) as IZTDialogWindow;
                Action<IZTDialogResult> requestCloseHandler = null;
                requestCloseHandler = (o) =>
                {
                    window.Result = o;
                    window.Close();
                };
                RoutedEventHandler loadedHandler = null;
                loadedHandler = (o, e) =>
                {
                    window.Loaded -= loadedHandler;
                    window.GetDialogViewModel().RequestClose += requestCloseHandler;
                };
                window.Loaded += loadedHandler;
                CancelEventHandler closingHandler = null;
                closingHandler = (o, e) =>
                {
                    if (!window.GetDialogViewModel().CanCloseDialog()) e.Cancel = true;
                };
                window.Closing += closingHandler;
                EventHandler closedHandler = null;
                closedHandler = (o, e) =>
                {
                    window.Closed -= closedHandler;
                    window.Closing -= closingHandler;
                    window.GetDialogViewModel().RequestClose -= requestCloseHandler;
                    window.GetDialogViewModel().OnDialogClosed();
                    if (window.Result == null) window.Result = new ZTDialogResult();
                    callback?.Invoke(window.Result);
                    window.DataContext = null;
                    window.Content = null;
                };
                window.Closed += closedHandler;
                var content = Activator.CreateInstance(DialogViewCollection[dialogName]);
                if (!(content is FrameworkElement dialogContent))
                    throw new NullReferenceException("对话框的内容必须是FrameworkElement");
                //抓取当前需要传递的参数并且传递给对应视图的ViewModel
                if (!(dialogContent.DataContext is IZTDialogWindowAware viewModel))
                    throw new NullReferenceException("对话框的 ViewModel 必须实现 ILayDialogWindowAware 接口 ");
                ///////设置窗体样式//////
                var windowStyle = GetWindowStyle(dialogContent);
                if (windowStyle != null) window.Style = windowStyle;
                ///////填充内容//////
                window.Content = dialogContent;
                /////////填充数据上下文/////////
                window.DataContext = dialogContent.DataContext;
                if (window.Owner == null) window.Owner = Application.Current?.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
                //给对应的ViewModel传值
                ViewAndViewModelAction<IZTDialogWindowAware>(viewModel, d => d.OnDialogOpened(parameters));
                if (isModel) window.ShowDialog();
                else window.Show();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 弹起用户控件窗体
        /// </summary>
        /// <param name="dialogName"></param>
        /// <param name="parameters"></param>
        /// <param name="callback"></param>
        /// <param name="isModel"></param>
        /// <param name="tooken"></param>
        private static void AlertUserControl(string dialogName, IZTDialogParameter parameters, Action<IZTDialogResult> callback, bool isModel, string tooken)
        {
            DispatcherFrame dispatcherFrame = null;
            try
            {
                var view = Activator.CreateInstance(DialogViewCollection[dialogName]) as UserControl;
                if (view == null) throw new Exception($"{dialogName}未找到");
                ZTDialogHost host = null;
                if (tooken == null) host = DialogHosts["RootDialogTooken"];
                else host = DialogHosts[tooken];
                if (host == null) throw new Exception($"未找到弹窗组件");
                if (host.IsOpen) throw new Exception($"{view.GetType().Name}已开启，请先关闭当前窗体");
                ZTDialogUserControlWindow DialogView = new ZTDialogUserControlWindow()
                {
                    Content = view,
                    DataContext = view.DataContext
                };
                host.Content = DialogView;
                if (DialogView == null) return;
                host.IsOpen = true;
                IZTDialogUserControlWindow dialog = DialogView as IZTDialogUserControlWindow;
                Action<IZTDialogResult> requestCloseHandler = null;
                //窗体关闭的回调方法
                requestCloseHandler = (o) =>
                {
                    DialogView.Result = o;
                    //关闭窗体
                    host.IsOpen = false;
                    host.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(async () =>
                    {
                        await Task.Delay(100);
                        //窗体关闭后数据置空
                        DialogView = null;
                        host.Content = null;
                        host.DataContext = null;
                    }));
                };
                RoutedEventHandler LoadedHandler = null;
                LoadedHandler = (o, e) =>
                {
                    DialogView.Loaded -= LoadedHandler;
                    DialogView.GetDialogViewModel().RequestClose += requestCloseHandler;
                };
                dialog.Loaded += LoadedHandler;
                RoutedEventHandler UnloadedHandler = null;
                //窗体销毁后的事件
                UnloadedHandler = (o, e) =>
                {
                    dialog.Unloaded -= UnloadedHandler;
                    dialog.GetDialogViewModel().RequestClose -= requestCloseHandler;
                    //抓取回调后的数据并回传
                    if (dialog.Result == null) dialog.Result = new ZTDialogResult() { Result = Enums.ButtonResult.Default };
                    callback?.Invoke(dialog.Result);
                    //判断是否为模态弹窗
                    if (isModel)
                    {
                        //取消线程占用，允许进行ViewModel业务代码操作
                        dispatcherFrame.Continue = false;
                        ComponentDispatcher.PopModal();
                        dispatcherFrame = null;
                    }
                };
                dialog.Unloaded += UnloadedHandler;
                //抓取当前需要传递的参数并且传递给对应视图的ViewModel
                if (!(view.DataContext is IZTDialogAware viewModel))
                    throw new NullReferenceException("对话框的 ViewModel 必须实现 IDialogAware 接口 ");
                //给对应的ViewModel传值
                ViewAndViewModelAction<IZTDialogAware>(viewModel, d => d.OnDialogOpened(parameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //判断是否为模态弹窗
                if (isModel)
                {
                    //阻塞ViewModel业务操作
                    ComponentDispatcher.PushModal();
                    dispatcherFrame = new DispatcherFrame(true);
                    Dispatcher.PushFrame(dispatcherFrame);
                }
            }
        }

        /// <summary>
        /// 关闭当前窗体的弹窗
        /// </summary>
        /// <param name="tooken">需要关闭的的窗体Tooken</param>
        public static void Close(string tooken)
        {
            if (!DialogHosts.ContainsKey(tooken)) return;
            ZTDialogHost host = DialogHosts[tooken];
            host.IsOpen = false;
            host.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(async () =>
            {
                await Task.Delay(100);
                //窗体关闭后数据置空
                host.Content = null;
                host.DataContext = null;
            }));
        }
        /// <summary>
        /// 关闭所有弹窗
        /// </summary>
        public void CloseAll()
        {
            foreach (var item in DialogHosts)
            {
                ZTDialogHost host = DialogHosts[item.Key];
                host.IsOpen = false;
                host.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(async () =>
                {
                    await Task.Delay(100);
                    //窗体关闭后数据置空
                    host.Content = null;
                    host.DataContext = null;
                }));
            }
        }
        private static void ViewAndViewModelAction<T>(object view, Action<T> action)
        {
            if (view is T viewAsT)
                action(viewAsT);

            if (view is FrameworkElement element && element.DataContext is T viewModelAsT)
            {
                action(viewModelAsT);
            }
        }
    }
}
