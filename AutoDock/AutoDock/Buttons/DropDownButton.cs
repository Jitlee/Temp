using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Buttons
{
    public class DropDownButton : Button
    {
        static DropDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DropDownButton),
                new FrameworkPropertyMetadata(
                    typeof(DropDownButton)));
        }
    }
}
