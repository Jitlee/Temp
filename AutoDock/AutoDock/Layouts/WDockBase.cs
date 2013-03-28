using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace AutoDock.Layouts
{
    public abstract class WDockBase : Control
    {
        static WDockBase _prevFocusedElement = null;

        #region IsFocused Property

        internal static new DependencyProperty IsFocusedProperty =
            DependencyProperty.Register("IsFocused",
            typeof(bool),
            typeof(WDockBase),
            null);

        internal new bool IsFocused
        {
            get { return (bool)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }

        #endregion

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            if (this != _prevFocusedElement)
            {
                if (null != _prevFocusedElement)
                {
                    _prevFocusedElement.IsFocused = false;
                }
                _prevFocusedElement = this;
                _prevFocusedElement.IsFocused = true;
                //_prevFocusedElement.Focus();
            }
        }
    }
}
