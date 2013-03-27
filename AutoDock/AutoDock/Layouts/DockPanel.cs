using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Windows;

namespace AutoDock.Layouts
{
    [ContentProperty("Children")]
    [TemplatePart(Name="Part_Canvas", Type= typeof(Canvas))]
    public class DockPanel : Control
    {

        private readonly Collection<Layout> _children = new Collection<Layout>();

        public Collection<Layout> Children { get { return _children; } }

        static DockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DockPanel),
                new FrameworkPropertyMetadata(
                    typeof(DockPanel)));
        }

        public DockPanel()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
