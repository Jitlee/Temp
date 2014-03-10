using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDock.Layouts
{
    /// <summary>
    /// 停靠面板位置
    /// </summary>
    public enum WDock
    {
        Left,
        Top,
        Right,
        Bottom,
    }

    /// <summary>
    /// 停靠面板组合类型
    /// </summary>
    public enum WDockState
    {
        /// <summary>
        /// 停靠的
        /// </summary>
        Docked,

        /// <summary>
        /// 文档
        /// </summary>
        Document,

        /// <summary>
        /// 浮动的
        /// </summary>
        Floating,

        /// <summary>
        /// 自动隐藏
        /// </summary>
        AutoHide,

        /// <summary>
        /// 隐藏
        /// </summary>
        Hide,
    }
}
