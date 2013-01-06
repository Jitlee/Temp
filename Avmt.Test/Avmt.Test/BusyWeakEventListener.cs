using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Avmt.Test
{
    internal class BusyWeakEventListener : IWeakEventListener
    {
        private readonly FrameworkElement _parent;

        private readonly UIElement _element;

        private readonly Guid _id;

        public FrameworkElement Parent { get { return _parent; } }

        public UIElement Element { get { return _element; } }

        public Guid Id { get { return _id; } }

        #region 构造函数

        public BusyWeakEventListener(FrameworkElement parent, UIElement element, Guid id)
        {
            _parent = parent;
            _element = element;
            _id = id;

            IsVisibleWeakEventManager.AddListener(_parent, this);
            LoadedWeakEventManager.AddListener(_parent, this);
            SizeChangedWeakEventManager.AddListener(_parent, this);
        }

        #endregion

        #region 重载方法

        public override bool Equals(object obj)
        {
            var listener = obj as BusyWeakEventListener;
            if (null != listener)
            {
                return listener._id.Equals(_id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region 接口实现

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(IsVisibleWeakEventManager))
            {
                IsVisibleChanged(sender, (IsVisibleChangedEventArgs)e);
            }
            else if (managerType == typeof(LoadedWeakEventManager))
            {
                Loaded(sender, (RoutedEventArgs)e);
            }
            else if (managerType == typeof(SizeChangedWeakEventManager))
            {
                SizeChanged(sender, (SizeChangedEventArgs)e);
            }
            else
            {
                return false;
            }
            return true;
        }

        #endregion

        #region 公共方法

        public void Disopse()
        {
            //OnRemoveChild();
            IsVisibleWeakEventManager.RemoveListener(_parent, this);
            SizeChangedWeakEventManager.RemoveListener(_parent, this);
            LoadedWeakEventManager.RemoveListener(_parent, this);
        }

        #endregion

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
