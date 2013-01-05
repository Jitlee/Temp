using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace Avmt.Test
{
    internal class BackgroundVisualHost
    {
        private static readonly Dictionary<FrameworkElement, List<Guid>> _childrenMap = new Dictionary<FrameworkElement, List<Guid>>();
        private static readonly HashSet<BusyWeakEventListener> _childrenListeners = new HashSet<BusyWeakEventListener>();

        #region 属性

        #region ElementId

        private static readonly DependencyPropertyKey ElementIdPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "ElementId",
                typeof(Guid),
                typeof(WindowBackgroundVisualHost),
                null);

        private static readonly DependencyProperty ElementIdProperty = ElementIdPropertyKey.DependencyProperty;

        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        private static Guid GetElementId(UIElement obj)
        {
            return (Guid)obj.GetValue(ElementIdProperty);
        }

        private static void SetElementId(UIElement obj, Guid value)
        {
            obj.SetValue(ElementIdPropertyKey, value);
        }

        #endregion

        #region BackgroundHost

        private static readonly DependencyPropertyKey BackgroundHostPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "BackgroundHost",
                typeof(WindowBackgroundVisualHost),
                typeof(WindowBackgroundVisualHost),
                null);

        private static readonly DependencyProperty BackgroundHostProperty = BackgroundHostPropertyKey.DependencyProperty;

        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        private static WindowBackgroundVisualHost GetBackgroundHost(UIElement obj)
        {
            return (WindowBackgroundVisualHost)obj.GetValue(BackgroundHostProperty);
        }

        private static void SetBackgroundHost(UIElement obj, WindowBackgroundVisualHost value)
        {
            obj.SetValue(BackgroundHostPropertyKey, value);
        }

        #endregion



        #endregion

        #region 构造函数

        static WindowBackgroundVisualHost GetHost(UIElement element)
        {
            var root = element.VisualAncestors().OfType<UIElement>().LastOrDefault();
            if (root != null)
            {
                var host = GetBackgroundHost(root);
                if (host == null)
                {
                    var decorator = root.VisualDescendants().OfType<AdornerDecorator>().FirstOrDefault();
                    if (decorator != null && decorator.Child != null)
                    {
                        host = new WindowBackgroundVisualHost(decorator.Child);
                        if (decorator is BusyAdornerDecorator)
                        {
                            ((BusyAdornerDecorator)decorator).BusyIndicatorHost = host;
                        }
                        else
                        {
                            decorator.AdornerLayer.Add(host);
                        }

                        SetBackgroundHost(root, host);
                        return host;
                    }
                }
            }
            return null;
        }

        #endregion

        public static Guid AddChild(FrameworkElement parent, UIElement element)
        {
            var id = Guid.NewGuid();
            var listener = new BusyWeakEventListener(parent, element, id, );
            _childrenListeners.Add(listener);
            return id;
        }

        #region 私有方法

        private void IsVisibleChanged(object sender, IsVisibleChangedEventArgs e)
        {
            if (e.IsVisible)
            {
                //OnAddChild();
            }
            else
            {
                //OnRemoveChild();
            }
        }

        private void Loaded(object sender, RoutedEventArgs e)
        {
            //OnAddChild();
        }

        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        #endregion
    }
}
