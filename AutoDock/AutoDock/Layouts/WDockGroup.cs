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
    [TemplatePart(Name = "PART_Headers", Type = typeof(ListBox))]
    public abstract class WDockGroup : WDockLayoutBase
    {
        #region 变量

        private readonly ObservableCollection<WDockContent> _items = new ObservableCollection<WDockContent>();

        private ListBox _headers = null;

        #endregion

        #region 属性

        #region Items

        public ObservableCollection<WDockContent> Items
        {
            get { return _items; }
        }

        #endregion

        #region SelectedIndex

        public static DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register
            (
                "SelectedIndex",
                typeof(int),
                typeof(WDockGroup),
                new FrameworkPropertyMetadata
                    (
                        -1,
                        OnSelectedIndexPropertyChanged,
                        OnSelectedIndexPropertyCoerceValue
                    )
            );

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
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
            SelectedItem = newValue > -1 && newValue < _items.Count ? _items[newValue] : null;
        }

        private static object OnSelectedIndexPropertyCoerceValue(DependencyObject o, object baseValue)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                var selectedIndex = (int)baseValue;
                return element.OnSelectedIndexCoerceValue((int)baseValue);
            }
            return -1;
        }

        private int OnSelectedIndexCoerceValue(int baseValue)
        {
            if (_items.Count > 0)
            {
                if (baseValue == -1)
                {
                    return 0;
                }
                else if (baseValue >= _items.Count)
                {
                    return _items.Count - 1;
                }
                return baseValue;
            }
            return -1;
        }

        #endregion

        #region SelectedItem

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register
            (
                "SelectedItem",
                typeof(WDockContent),
                typeof(WDockGroup),
                new FrameworkPropertyMetadata
                    (
                        null,
                        OnSelectedItemPropertyChanged
                    )
            );

        public WDockContent SelectedItem
        {
            get { return (WDockContent)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
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
            SelectedContent = null != newValue ? newValue.Content : null;
            SelectedHeader = null != newValue ? newValue.Header : null;
        }

        private static object OnSelectedItemPropertyCoerceValue(DependencyObject o, object baseValue)
        {
            var element = o as WDockGroup;
            if (null != element)
            {
                var SelectedItem = (WDockContent)baseValue;
                return element.OnSelectedItemCoerceValue((WDockContent)baseValue);
            }
            return null;
        }

        private object OnSelectedItemCoerceValue(WDockContent baseValue)
        {
            var index = _items.IndexOf(baseValue);
            if (index > -1)
            {
                SelectedIndex = index;
            }
            return null;
        }

        #endregion

        #region SelectedContent

        internal static DependencyProperty SelectedContentProperty =
            DependencyProperty.Register
            (
                "SelectedContent",
                typeof(object),
                typeof(WDockGroup),
                null
            );

        internal object SelectedContent
        {
            get { return GetValue(SelectedContentProperty); }
            private set { SetValue(SelectedContentProperty, value); }
        }

        #endregion

        #region SelectedHeader

        internal static DependencyProperty SelectedHeaderProperty =
            DependencyProperty.Register
            (
                "SelectedHeader",
                typeof(object),
                typeof(WDockGroup),
                null
            );

        internal object SelectedHeader
        {
            get { return GetValue(SelectedHeaderProperty); }
            private set { SetValue(SelectedHeaderProperty, value); }
        }

        #endregion

        #endregion

        #region 重载

        public override void EndInit()
        {
            base.EndInit();

            if (_items.Count > 0)
            {
                if (SelectedIndex == -1)
                {
                    SelectedIndex = 0;
                }
                else if (SelectedIndex >= _items.Count)
                {
                    SelectedIndex = _items.Count - 1;
                }
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _headers = GetTemplateChild("PART_Headers") as ListBox;

        }

        #endregion
    }
}
