using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;

namespace AutoDock.Layouts
{
    [ContentProperty("Children")]
    [TemplatePart(Name = "PART_DockGrid", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_DocumentGroup", Type = typeof(WDocumentGroup))]
    public class WDockLayoutManager : Control
    {
        #region 变量

        private readonly ObservableCollection<WDockLayoutBase> _children = new ObservableCollection<WDockLayoutBase>();

        private Grid _dockGrid = null;

        private WDocumentGroup _documentGroup = null;

        #endregion

        #region 属性

        public ObservableCollection<WDockLayoutBase> Children { get { return _children; } }

        #endregion

        #region 构造函数

        static WDockLayoutManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDockLayoutManager),
                new FrameworkPropertyMetadata(
                    typeof(WDockLayoutManager)));
        }

        #endregion

        #region 重载

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _dockGrid = GetTemplateChild("PART_DockGrid") as Grid;
            _documentGroup = GetTemplateChild("PART_DocumentGroup") as WDocumentGroup;

            _dockGrid.RowDefinitions.Add(new RowDefinition() { MinHeight = 30d });

            _dockGrid.ColumnDefinitions.Add(new ColumnDefinition() { MinWidth = 30d });

            foreach (var child in _children)
            {
                child.DockManager = this;
                LayoutChild(child);
            }
        }

        #endregion

        #region 私有函数

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

        private void LayoutDocked(WDockLayoutBase child)
        {
            child.OriginHeight = child.Height;
            child.OriginWidth = child.Width;
            child.OriginMargin = child.Margin;
            var documentRow = Grid.GetRow(_documentGroup);
            var documentColumn = Grid.GetColumn(_documentGroup);
            var gridSplitter = new WGridSplitter();
            var minSize = 30d;
            child.Splitter = gridSplitter;
            child.ClearValue(HeightProperty);
            child.ClearValue(WidthProperty);
            child.SetValue(MarginProperty, new Thickness(5d));
            switch (child.Dock)
            {
                case WDock.Left:

                    _dockGrid.ColumnDefinitions.Insert(documentColumn, new ColumnDefinition() { Width = new GridLength(child.OriginWidth), MinWidth = minSize });

                    foreach (UIElement layout in _dockGrid.Children)
                    {
                        var originColumn = Grid.GetColumn(layout);
                        var originRow = Grid.GetRow(layout);
                        if (originColumn > documentColumn ||    // 大于列所有格子
                            layout == _documentGroup)           // 中心格子
                        {
                            // 大于列所有格子(包括中心格子)右移
                            layout.SetValue(Grid.ColumnProperty, originColumn + 1);
                        }
                        else if (documentColumn == originColumn && documentRow != originRow)
                        {
                            // 同一列不同行的格子ColmunSpan加一
                            var originColumnSpan = Grid.GetColumnSpan(layout);
                            layout.SetValue(Grid.ColumnSpanProperty, originColumnSpan + 1);
                        }
                    }
                    
                    child.SetValue(Grid.RowProperty, documentRow);
                    child.SetValue(Grid.ColumnProperty, documentColumn);

                    gridSplitter.HorizontalAlignment = HorizontalAlignment.Right;
                    gridSplitter.Width = 5d;
                    gridSplitter.SetValue(Grid.RowProperty, documentRow);
                    gridSplitter.SetValue(Grid.ColumnProperty, documentColumn);
                    break;

                case WDock.Top:

                    _dockGrid.RowDefinitions.Insert(documentRow, new RowDefinition() { Height = new GridLength(child.OriginHeight), MinHeight = minSize });

                    foreach (UIElement layout in _dockGrid.Children)
                    {
                        var originColumn = Grid.GetColumn(layout);
                        var originRow = Grid.GetRow(layout);
                        if (originRow > documentRow ||      // 大于行所有格子
                            layout == _documentGroup)       // 中心格子
                        {
                            // 大于列所有格子(包括中心格子)下移
                            layout.SetValue(Grid.RowProperty, originRow + 1);
                        }
                        else if (originRow == documentRow && documentColumn != originColumn)
                        {
                            // 同一行不同列的格子RowSpan加一
                            var originRowSpan = Grid.GetRowSpan(layout);
                            layout.SetValue(Grid.RowSpanProperty, originRowSpan + 1);
                        }
                    }

                    child.SetValue(Grid.RowProperty, documentRow);
                    child.SetValue(Grid.ColumnProperty, documentColumn);

                    gridSplitter.VerticalAlignment = VerticalAlignment.Bottom;
                    gridSplitter.HorizontalAlignment = HorizontalAlignment.Stretch;
                    gridSplitter.Height = 5d;
                    gridSplitter.SetValue(Grid.RowProperty, documentRow);
                    gridSplitter.SetValue(Grid.ColumnProperty, documentColumn);
                    break;

                case WDock.Right:

                    _dockGrid.ColumnDefinitions.Insert(documentColumn + 1, new ColumnDefinition() { Width = new GridLength(child.OriginWidth), MinWidth = minSize });

                    foreach (UIElement layout in _dockGrid.Children)
                    {
                        var originColumn = Grid.GetColumn(layout);
                        var originRow = Grid.GetRow(layout);
                        var originColumnSpan = Grid.GetColumnSpan(layout);
                        if (originColumn > documentColumn)
                        {
                            // 大于列的都加一
                            layout.SetValue(Grid.ColumnProperty, originColumn + 1);
                        }
                        else if (originColumn + originColumnSpan > documentColumn && originRow != documentRow)
                        {
                            // 列+跨列>当前列,且行不相等的单元格 列跨度再加一
                            layout.SetValue(Grid.ColumnSpanProperty, originColumnSpan + 1);
                        }
                    }

                    child.SetValue(Grid.RowProperty, documentRow);
                    child.SetValue(Grid.ColumnProperty, documentColumn + 1);

                    gridSplitter.HorizontalAlignment = HorizontalAlignment.Left;
                    gridSplitter.Width = 5d;
                    gridSplitter.SetValue(Grid.RowProperty, documentRow);
                    gridSplitter.SetValue(Grid.ColumnProperty, documentColumn + 1);
                    break;

                case WDock.Bottom:

                    _dockGrid.RowDefinitions.Insert(documentRow + 1, new RowDefinition() { Height = new GridLength(child.OriginHeight), MinHeight = minSize });

                    foreach (UIElement layout in _dockGrid.Children)
                    {
                        var originColumn = Grid.GetColumn(layout);
                        var originRow = Grid.GetRow(layout);
                        var originRowSpan = Grid.GetRowSpan(layout);
                        if (originRow > documentRow) 
                        {
                            // 大于行的都加一
                            layout.SetValue(Grid.RowProperty, originRow + 1);
                        }
                        else if (originRow + originRowSpan > documentRow && documentColumn != originColumn)
                        {
                            // 行+跨行>当前行,且列不相等的单元格 行跨度再加一
                            layout.SetValue(Grid.RowSpanProperty, originRowSpan + 1);
                        }
                    }

                    child.SetValue(Grid.RowProperty, documentRow + 1);
                    child.SetValue(Grid.ColumnProperty, documentColumn);

                    gridSplitter.VerticalAlignment = VerticalAlignment.Top;
                    gridSplitter.HorizontalAlignment = HorizontalAlignment.Stretch;
                    gridSplitter.Height = 5d;
                    gridSplitter.SetValue(Grid.RowProperty, documentRow + 1);
                    gridSplitter.SetValue(Grid.ColumnProperty, documentColumn);
                    break;
            }

            _dockGrid.Children.Add(child);
            _dockGrid.Children.Add(gridSplitter);
        }

        #endregion


    }
}