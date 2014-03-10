
using System.Windows.Controls;
using System.Windows;
namespace AutoDock.Layouts
{
    internal class WGridSplitter : GridSplitter
    {
        static WGridSplitter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WGridSplitter),
                new FrameworkPropertyMetadata(
                    typeof(WGridSplitter)));
        }
    }
}
