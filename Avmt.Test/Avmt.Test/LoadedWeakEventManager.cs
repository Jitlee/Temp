using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Avmt.Test
{
    internal class LoadedWeakEventManager : WeakEventManagerBase<LoadedWeakEventManager, FrameworkElement>
    {
        protected override void Start(FrameworkElement source)
        {
            source.Loaded += base.DeliverEvent;
        }

        protected override void Stop(FrameworkElement source)
        {
            source.Loaded -= base.DeliverEvent;
        }
    }
}
