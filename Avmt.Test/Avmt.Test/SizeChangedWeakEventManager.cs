using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Avmt.Test
{
    internal class SizeChangedWeakEventManager : WeakEventManagerBase<SizeChangedWeakEventManager, FrameworkElement>
    {

        protected override void Start(FrameworkElement source)
        {
            source.SizeChanged += base.DeliverEvent;
        }

        protected override void Stop(FrameworkElement source)
        {
            source.SizeChanged -= base.DeliverEvent;
        }
    }
}
