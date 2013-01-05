using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Avmt.Test
{
    internal class BusyAdornerDecorator : AdornerDecorator
    {
        #region BusyIndicatorHost Dependency Property

        internal static readonly DependencyProperty BusyIndicatorHostProperty =
            DependencyProperty.Register(
                "BusyIndicatorHost",
                typeof(FrameworkElement),
                typeof(BusyAdornerDecorator),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        internal FrameworkElement BusyIndicatorHost
        {
            get { return (FrameworkElement)GetValue(BusyIndicatorHostProperty); }
            set { SetValue(BusyIndicatorHostProperty, value); }
        }

        #endregion

        #region 重载方法

        protected override Size MeasureOverride(Size constraint)
        {
            if (null != BusyIndicatorHost)
            {
                BusyIndicatorHost.Measure(constraint);
            }
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var rect = new Rect(finalSize);

            if (Child != null)
                Child.Arrange(rect);

            if (BusyIndicatorHost != null)
                BusyIndicatorHost.Arrange(rect);

            if (VisualTreeHelper.GetParent(AdornerLayer) != null)
                AdornerLayer.Arrange(rect);

            return base.ArrangeOverride(finalSize);
        }

        protected override int VisualChildrenCount
        {
            get
            {
                var count = base.VisualChildrenCount;
                if (null != BusyIndicatorHost)
                {
                    count++;
                }
                return count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            switch (index)
            {
                case 0:
                    return Child;
                case 1:
                    if (null != BusyIndicatorHost)
                    {
                        return BusyIndicatorHost;
                    }
                    else
                    {
                        return AdornerLayer;
                    }
                case 2:
                    if (BusyIndicatorHost == null)
                        throw new ArgumentOutOfRangeException("index");
                    else
                        return AdornerLayer;
                default:
                    throw new ArgumentOutOfRangeException("index");
            }
        }

        #endregion
    }
}
