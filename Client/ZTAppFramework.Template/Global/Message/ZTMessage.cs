using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZTAppFramework.Template.Control;

namespace ZTAppFramework.Template.Global
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/23 9:39:16 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class ZTMessage
    {
        /// <summary>
        /// 全局Message组件
        /// </summary>
        internal static Dictionary<string, ZTMessageHost> MessageHosts { get; set; } = MessageHosts ?? new Dictionary<string, ZTMessageHost>();


        #region Tooken
        public static string GetTooken(DependencyObject obj)
        {
            return (string)obj.GetValue(TookenProperty);
        }

        public static void SetTooken(DependencyObject obj, string value)
        {
            obj.SetValue(TookenProperty, value);
        }

        // Using a DependencyProperty as the backing store for TookenProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TookenProperty =
            DependencyProperty.RegisterAttached("Tooken", typeof(string), typeof(ZTMessage), new PropertyMetadata(OnTookenChange));


        #endregion

        #region Event
        private static void OnTookenChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ZTMessageHost host = d as ZTMessageHost;
                if (host == null) return;
                var tooken = ZTMessage.GetTooken(host);
                if (!ZTMessage.MessageHosts.ContainsKey(tooken)) ZTMessage.MessageHosts.Add(tooken, host);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region MessageHandel

        /// <summary>
        /// 默认提示信息（无图标效果）
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="tooken">自定义指定提示窗口</param>
        /// <param name="time">停留时间</param>
        public static void Default(object message, string tooken = null, double time = 3) => Show(message, Enums.MessageStyle.Default, tooken, time);
        /// <summary>
        /// 成功信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="tooken">自定义指定提示窗口</param>
        /// <param name="time">停留时间</param>
        public static void Success(object message, string tooken = null, double time = 3) => Show(message, Enums.MessageStyle.Success, tooken, time);
        /// <summary>
        /// 警告信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="tooken">自定义指定提示窗口</param>
        /// <param name="time">停留时间</param>
        public static void Warning(object message, string tooken = null, double time = 3) => Show(message, Enums.MessageStyle.Warning, tooken, time);
        /// <summary>
        /// 错误信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="tooken">自定义指定提示窗口</param>
        /// <param name="time">停留时间</param>
        public static void Error(object message, string tooken = null, double time = 3) => Show(message, Enums.MessageStyle.Error, tooken, time);

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="type">提示类型</param>
        /// <param name="tooken">自定义指定提示窗口</param>
        /// <param name="time">停留时间</param>
        private static void Show(object message, Enums.MessageStyle type, string tooken, double time)
        {
            if (tooken == null)
            {
                if (!MessageHosts.ContainsKey("RootMessageTooken")) return;
                var view = MessageHosts.Where(o => o.Key.Equals("RootMessageTooken")).FirstOrDefault().Value;
                view.Items.Add(new ZTMessageControl() { Type = type, Content = message, Time = time, Uid = Guid.NewGuid().ToString() });
            }
            else
            {

                if (!MessageHosts.ContainsKey(tooken)) return;
                var view = MessageHosts.Where(o => o.Key.Equals(tooken)).FirstOrDefault().Value;
                view.Items.Add(new ZTMessageControl() { Type = type, Content = message, Time = time, Uid = Guid.NewGuid().ToString() });
            }
        }
        #endregion


    }
}
