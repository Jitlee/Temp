using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Avmt.Test
{
    internal class WindowBackgroundVisualHost : Adorner
    {
        private readonly HostVisual _hostVisual = new HostVisual();
        private readonly HashSet<Guid> _children = new HashSet<Guid>();
        private readonly AutoResetEvent _sync = new AutoResetEvent(false);
        private Canvas _root;
            
        #region 构造函数

        public WindowBackgroundVisualHost(UIElement adornedElement)
            :base(adornedElement)
        {
            var thread = new Thread(CreateAndRun);
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "WindowBackgroundVisualHostThread";
            thread.Start();

            AddLogicalChild(_hostVisual);
            AddVisualChild(_hostVisual);

            _sync.WaitOne();
        }

        #endregion

        #region 重载方法

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index == 0)
            {
                return _hostVisual;
            }
            throw new IndexOutOfRangeException();
        }

        protected override System.Collections.IEnumerator LogicalChildren
        {
            get
            {
                yield return _hostVisual;
            }
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        #endregion

        #region 公共方法

        public void AddChild(UIElement element, Guid id, Rect bounds)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (!_children.Add(id))
                {
                    _root.Children.Add(element);

                }
            }));
        }

        #endregion

        #region 私有方法

        private void CreateAndRun()
        {
            using (var source = new VisualTargetPresentationSource(_hostVisual))
            {
                _root = new Canvas();

                _sync.Set();

                source.RootVisual = _root;

                Dispatcher.Run();
                source.Dispose();
            }
        }

        #endregion
    }
}
