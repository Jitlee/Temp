using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutoDock.Layouts
{
    public class LayoutGroup : TabControl
    {
        static LayoutGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(LayoutGroup),
                new FrameworkPropertyMetadata(
                    typeof(LayoutGroup)));
        }

        public LayoutGroup()
        {
        }
    }
}
