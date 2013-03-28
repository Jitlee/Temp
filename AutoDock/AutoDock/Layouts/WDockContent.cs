using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace AutoDock.Layouts
{
    [ContentProperty("Content")]
    public sealed class WDockContent : WDockLayoutBase
    {
        #region 变量

        #endregion

        #region 属性

        #region Header Property

        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header",
            typeof(object),
            typeof(WDockContent),
            new PropertyMetadata("Auto dock panel"));

        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        #endregion

        #region Content Property

        public static DependencyProperty ContentProperty =
            DependencyProperty.Register("Content",
            typeof(object),
            typeof(WDockContent),
            null);

        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        #endregion

        #endregion

        #region 构造函数

        static WDockContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDockContent),
                new FrameworkPropertyMetadata(
                    typeof(WDockContent)));
        }

        #endregion
    }
}
