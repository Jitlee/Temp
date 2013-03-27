using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Buttons
{
    public class WDropDownButton : Button
    {
        static WDropDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDropDownButton),
                new FrameworkPropertyMetadata(
                    typeof(WDropDownButton)));
        }
    }
}
