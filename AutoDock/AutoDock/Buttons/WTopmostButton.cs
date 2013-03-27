using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Buttons
{
    public class WTopmostButton : Button
    {
        static WTopmostButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WTopmostButton),
                new FrameworkPropertyMetadata(
                    typeof(WTopmostButton)));
        }
    }
}
