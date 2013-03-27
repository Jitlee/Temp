using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoDock.Layouts
{
    public class WDockContent : WDockContentBase
    {
        #region 变量

        #endregion

        #region 属性

        

        #region Title Property

        public static DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
            typeof(string),
            typeof(WDockContent),
            new PropertyMetadata("Auto dock panel"));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
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
