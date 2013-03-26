using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutoDock.Buttons
{
    public class CloseButton : Button
    {
        static CloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CloseButton),
                new FrameworkPropertyMetadata(
                    typeof(CloseButton)));
        }
    }
}
