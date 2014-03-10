using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutoDock.Layouts
{
    public abstract class WDockLayoutBase : WDockBase
    {
        #region 变量

        private readonly ObservableCollection<WDockLayoutBase> _children = new ObservableCollection<WDockLayoutBase>();
        
        #endregion

        #region 属性
        
        public ObservableCollection<WDockLayoutBase> Children { get { return _children; } }

        internal WGridSplitter Splitter { get; set; }

        internal WDockLayoutBase DockParent { get; set; }

        internal WDockLayoutManager DockManager { get; set; }

        #region Origin Property

        internal double OriginHeight { get; set; }

        internal double OriginWidth { get; set; }

        internal Thickness OriginMargin { get; set; }

        #endregion

        #region Dock

        public static DependencyProperty DockProperty =
            DependencyProperty.Register
            (
                "Dock",
                typeof(WDock),
                typeof(WDockLayoutBase),
                new PropertyMetadata
                    (
                        default(WDock),
                        OnDockPropertyChanged
                    )
            );

        public WDock Dock
        {
            get { return (WDock)GetValue(DockProperty); }
            set { SetValue(DockProperty, value); }
        }

        private static void OnDockPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockLayoutBase;
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

        public static DependencyProperty DockStateProperty =
            DependencyProperty.Register
            (
                "DockState",
                typeof(WDockState),
                typeof(WDockLayoutBase),
                new PropertyMetadata
                    (
                        default(WDockState),
                        OnDockStatePropertyChanged
                    )
            );

        public WDockState DockState
        {
            get { return (WDockState)GetValue(DockStateProperty); }
            set { SetValue(DockStateProperty, value); }
        }

        private static void OnDockStatePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var element = o as WDockLayoutBase;
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
    }
}
