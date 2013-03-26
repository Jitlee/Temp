using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Layouts
{
    public class LayoutGroupItem : TabItem
    {
        static LayoutGroupItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(LayoutGroupItem),
                new FrameworkPropertyMetadata(
                    typeof(LayoutGroupItem)));
        }
    }
}
