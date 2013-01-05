using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Avmt.Test
{
    internal class IsVisibleWeakEventManager : WeakEventManagerBase<IsVisibleWeakEventManager, FrameworkElement>
    {
        protected override void Start(FrameworkElement source)
        {
            source.IsVisibleChanged += DeliverEvent;
        }

        protected override void Stop(FrameworkElement source)
        {
            source.IsVisibleChanged -= DeliverEvent;
        }

        private void DeliverEvent(object sender, DependencyPropertyChangedEventArgs e)
        {
            base.DeliverEvent(sender, EventArgs.Empty);
        }
    }
}
