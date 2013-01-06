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

        #region 公共方法

        public static Guid AddChild(FrameworkElement parent, UIElement element)
        {
            var id = Guid.NewGuid();
            var listener = new BusyWeakEventListener(parent, element, id);
            _childrenListeners.Add(listener);
            return id;
        }

        public static void AddChild(BusyWeakEventListener listener)
        {
            var parent = listener.Parent;
            var element = listener.Element;
            var id = listener.Id;
            var root = parent.VisualAncestors().OfType<UIElement>().LastOrDefault();
            if (null != root)
            {
                var transform = parent.TransformToAncestor(root);
                var bounds = transform.TransformBounds(new Rect(parent.RenderSize));
                var host = GetHost(parent);

                if (null != host)
                {
                    host.AddChild(element, id, bounds);
                }

                List<Guid> children;
                if (!_childrenMap.TryGetValue(parent, out children))
                {
                    children = new List<Guid>();
                    _childrenMap.Add(parent, children);
                }

                children.Add(id);
            }
        }

        #endregion

        #region 私有方法

        #endregion
    }
}
