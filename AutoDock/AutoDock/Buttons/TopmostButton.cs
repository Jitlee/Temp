using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Buttons
{
    public class TopmostButton : Button
    {
        static TopmostButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TopmostButton),
                new FrameworkPropertyMetadata(
                    typeof(TopmostButton)));
        }
    }
}
