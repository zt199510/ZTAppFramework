using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Template.Enums
{

    public enum InputType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 数字
        /// </summary>
        Number,
        /// <summary>
        /// 电话
        /// </summary>
        Phone,
        /// <summary>
        /// 正则表达式
        /// </summary>
        Regex
    }

    #region 按钮
    public enum ButtonStyle
    {
        /// <summary>
        /// 原始
        /// </summary>
        Primary,
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 百搭
        /// </summary>
        Normal,
        /// <summary>
        /// 暖色
        /// </summary>
        Warm,
        /// <summary>
        /// 警告
        /// </summary>
        Danger,

    }


    public enum ButtonType
    {
        Standard,
        Link,
    }


    #endregion


    #region ProgressBarStyle
    public enum ProgressBarStyle
    {
        Standard,
        Ring
    }
    #endregion

    #region CheckBox
    public enum CheckBoxStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion

    #region RadioButton
    public enum RadioButtonStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion

    #region Message
    public enum MessageStyle
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 错误
        /// </summary>
        Error
    }
    #endregion

    #region DataGridStyle
    public enum DataGridStyle
    {
        /// <summary>
        /// 默认
        /// </summary>
        Standard,
        /// <summary>
        /// Layui
        /// </summary>
        Layui,
    }
    #endregion

    #region Windows
    /// <summary>
    /// 过度动画枚举
    /// </summary>
    public enum AnimationType
    {
        /// <summary>
        /// 缩放
        /// </summary>
        Zoom,
        /// <summary>
        /// 渐变
        /// </summary>
        Gradient,
        /// <summary>
        /// 默认无效果
        /// </summary>
        Default,
        /// <summary>
        /// 底部滑入
        /// </summary>
        SlideInToBottom,
        /// <summary>
        /// 底部滑出
        /// </summary>
        SlideOutToBottom,
        /// <summary>
        /// 右侧滑入
        /// </summary>
        SlideInToRight,
        /// <summary>
        /// 右侧滑出
        /// </summary>
        SlideOutToRight,
        /// <summary>
        /// 顶部滑入
        /// </summary>
        SlideInToTop,
        /// <summary>
        /// 顶部滑出
        /// </summary>
        SlideOutToTop,
        /// <summary>
        /// 左侧滑入
        /// </summary>
        SlideInToLeft,
        /// <summary>
        /// 左侧滑出
        /// </summary>
        SlideOutToLeft
    }
    #endregion

    #region LoadingStyle
    /// <summary>
    /// 记载动画枚举类型
    /// </summary>
    public enum LoadingStyle
    {
        /// <summary>
        /// 谷歌
        /// </summary>
        Google,
        /// <summary>
        /// 百搭
        /// </summary>
        Normal,
        /// <summary>
        /// 简约
        /// </summary>
        Simple,
        /// <summary>
        /// 跳动
        /// </summary>
        Beat
    }
    #endregion

    #region ComboBoxStyle
    public enum ComboBoxStyle
    {
        Standard,
        Editable,
        Menu
    }
    #endregion

}
