using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.ComponentModel;
using System.Windows;

namespace AutoDock.Layouts
{
    [ContentProperty("Items")]
    [TemplatePart(Name="PART_Tab", Type=typeof(StackPanel))]
    public abstract class WDockGroup : Control
    {
        #region 变量

        private readonly Collection<WDockContent> _items = new Collection<WDockContent>();

        private StackPanel _tab = null;

        #endregion

        #region 属性
        
        public Collection<WDockContent> Items { get { return _items; } }

        #region SelectedItem

        public static DependencyProperty SelectedItemProperpty =
            DependencyProperty.Register
            (
                "SelectedItem",
                typeof(WDockContent),
                typeof(WDockGroup),
                new PropertyMetadata
                    (
                        null,
                        OnSelectedItemPropertyChanged
                    )
            );

        public WDockContent SelectedItem
        {
            get { return (WDockContent)GetValue(SelectedItemProperpty); }
            set { SetValue(SelectedItemProperpty, value); }
        }

        private static void OnSelectedItemPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                element.OnSelectedItemChanged((WDockContent)e.NewValue, (WDockContent)e.OldValue);
            }
        }

        private void OnSelectedItemChanged(WDockContent newValue, WDockContent oldValue)
        {

        }

        #endregion

        #region SelectedIndex

        public static DependencyProperty SelectedIndexProperpty =
            DependencyProperty.Register
            (
                "SelectedIndex",
                typeof(int),
                typeof(WDockGroup),
                new PropertyMetadata
                    (
                        -1,
                        OnSelectedIndexPropertyChanged
                    )
            );

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperpty); }
            set { SetValue(SelectedIndexProperpty, value); }
        }

        private static void OnSelectedIndexPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                element.OnSelectedIndexChanged((int)e.NewValue, (int)e.OldValue);
            }
        }

        private void OnSelectedIndexChanged(int newValue, int oldValue)
        {

        }

        #endregion

        #region SelectedContent

        public static DependencyProperty SelectedContentProperpty =
            DependencyProperty.Register
            (
                "SelectedContent",
                typeof(object),
                typeof(WDockGroup),
                null
            );

        public object SelectedContent
        {
            get { return GetValue(SelectedContentProperpty); }
            private set { SetValue(SelectedContentProperpty, value); }
        }

        #endregion

        #region Dock

        public static DependencyProperty DockProperpty =
            DependencyProperty.Register
            (
                "Dock",
                typeof(WDock),
                typeof(WDockGroup),
                new PropertyMetadata
                    (
                        default(WDock),
                        OnDockPropertyChanged
                    )
            );

        public WDock Dock
        {
            get { return (WDock)GetValue(DockProperpty); }
            set { SetValue(DockProperpty, value); }
        }

        private static void OnDockPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                element.OnDockChanged((WDock)e.NewValue, (WDock)e.OldValue);
            }
        }

        private void OnDockChanged(WDock newValue, WDock oldValue)
        {

        }

        #endregion

        #region DockState

        public static DependencyProperty DockStateProperpty =
            DependencyProperty.Register
            (
                "DockState",
                typeof(WDockState),
                typeof(WDockGroup),
                new PropertyMetadata
                    (
                        default(WDockState),
                        OnDockStatePropertyChanged
                    )
            );

        public WDockState DockState
        {
            get { return (WDockState)GetValue(DockStateProperpty); }
            set { SetValue(DockStateProperpty, value); }
        }

        private static void OnDockStatePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                element.OnDockStateChanged((WDockState)e.NewValue, (WDockState)e.OldValue);
            }
        }

        private void OnDockStateChanged(WDockState newValue, WDockState oldValue)
        {

        }

        #endregion

        #endregion

        #region 重载

        public override void EndInit()
        {
            base.EndInit();

            if (_items.Count > 0)
            {
                if (SelectedIndex == -1 || SelectedIndex >= _items.Count)
                {
                    SelectedIndex = 0;
                }
            }
            else if(SelectedIndex != -1)
            {
                SelectedIndex = -1;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _tab = GetTemplateChild("PART_Tab") as StackPanel;

        }

        #endregion
    }
}
