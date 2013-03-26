using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace AutoDock.Layouts
{
    public class Layout : ContentControl
    {
        static Layout _prevFocusedElement = null;
        static Layout()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Layout),
                new FrameworkPropertyMetadata(
                    typeof(Layout)));
        }

        #region Title Property

        public static DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
            typeof(string),
            typeof(Layout),
            new PropertyMetadata("Auto dock panel"));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region IsFocused Property

        public static new DependencyProperty IsFocusedProperty =
            DependencyProperty.Register("IsFocused",
            typeof(bool),
            typeof(Layout),
            new PropertyMetadata(false));

        public new bool IsFocused
        {
            get { return (bool)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }

        #endregion

        protected override void OnPreviewMouseDown(System.Windows.Input.MouseButtonEventArgs e)
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
                _prevFocusedElement.Focus();
            }
        }
    }
}
