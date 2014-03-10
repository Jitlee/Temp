using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Windows;
using SDock = System.Windows.Controls.Dock;

namespace AutoDock.Layouts
{
    [ContentProperty("Children")]
    [TemplatePart(Name = "PART_DockPanel", Type = typeof(DockPanel))]
    [TemplatePart(Name = "PART_DcoumentGrid", Type = typeof(Grid))]
    public class WDockLayout : WDockLayoutBase
    {
        #region 变量

        private DockPanel _dockPanel = null;

        private readonly ObservableCollection<WDockLayoutBase> _children = new ObservableCollection<WDockLayoutBase>();

        #endregion

        #region 属性



        #endregion

        static WDockLayout()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDockLayout),
                new FrameworkPropertyMetadata(
                    typeof(WDockLayout)));
        }

        public WDockLayout()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _dockPanel = GetTemplateChild("PART_DockPanel") as DockPanel;

            foreach (var child in _children)
            {
                LayoutChild(child);
            }
        }

        #region 私有方法

        private void LayoutChild(WDockLayoutBase child)
        {
            switch (child.DockState)
            {
                case WDockState.AutoHide:

                    break;
                case WDockState.Docked:
                    LayoutDocked(child);
                    break;
                case WDockState.Document:

                    break;
                case WDockState.Floating:

                    break;

                case WDockState.Hide:

                    break;
            }
        }

        private void LayoutDocked(WDockLayoutBase group)
        {
            group.OriginHeight = group.Height;
            group.OriginWidth = group.Width;
            var index = 0;
            switch (group.Dock)
            {
                case WDock.Left:
                    group.SetValue(DockPanel.DockProperty, SDock.Left);
                    group.ClearValue(HeightProperty);
                    break;

                case WDock.Top:
                    group.SetValue(DockPanel.DockProperty, SDock.Top);
                    group.ClearValue(WidthProperty);
                    break;

                case WDock.Right:
                    group.SetValue(DockPanel.DockProperty, SDock.Right);
                    group.ClearValue(HeightProperty);
                    break;

                case WDock.Bottom:
                    group.SetValue(DockPanel.DockProperty, SDock.Bottom);
                    group.ClearValue(WidthProperty);
                    break;
            }
            _dockPanel.Children.Insert(_dockPanel.Children.Count - 1, group);
        }

        #endregion
    }
}
