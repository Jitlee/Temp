using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Avmt.Test
{
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// 获取子可视对象
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static IEnumerable<DependencyObject> VisualDescendants(this DependencyObject d)
        {
            var tree = new Queue<DependencyObject>();
            tree.Enqueue(d);

            while (tree.Count > 0)
            {
                var item = tree.Dequeue();
                var count = VisualTreeHelper.GetChildrenCount(item);
                for (int i = 0; i < count; ++i)
                {
                    var child = VisualTreeHelper.GetChild(item, i);
                    tree.Enqueue(child);
                    yield return child;
                }
            }
        }

        /// <summary>
        /// 获取所有父辈的可视对象
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static IEnumerable<DependencyObject> VisualAncestors(this DependencyObject d)
        {
            var parent = VisualTreeHelper.GetParent(d);
            while (parent != null)
            {
                yield return parent;
                parent = VisualTreeHelper.GetParent(parent);
            }
        }
    }
}
