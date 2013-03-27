using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutoDock.Buttons
{
    public class WCloseButton : Button
    {
        static WCloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WCloseButton),
                new FrameworkPropertyMetadata(
                    typeof(WCloseButton)));
        }
    }
}
