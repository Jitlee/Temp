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
    [TemplatePart(Name = "PART_Canvas", Type = typeof(Canvas))]
    [TemplatePart(Name = "PART_Grid", Type = typeof(Grid))]
    public class WDockPanel : Control
    {
        #region 变量

        private Canvas _canvas = null;

        private Grid _grid = null;

        private readonly Collection<WDockGroup> _children = new Collection<WDockGroup>();

        #endregion

        #region 属性

        public Collection<WDockGroup> Children { get { return _children; } }

        #endregion

        static WDockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDockPanel),
                new FrameworkPropertyMetadata(
                    typeof(WDockPanel)));
        }

        public WDockPanel()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = GetTemplateChild("PART_Canvas") as Canvas;
            _grid = GetTemplateChild("PART_Grid") as Grid;

            foreach (var layout in _children)
            {
                _canvas.Children.Add(layout);
            }
        }


    }
}
