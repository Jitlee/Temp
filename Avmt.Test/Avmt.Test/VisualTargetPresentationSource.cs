using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Avmt.Test
{
    internal class VisualTargetPresentationSource : PresentationSource, IDisposable
    {
        private VisualTarget _visualTarget;
        private bool _isDisposed;

        public VisualTargetPresentationSource(HostVisual hostVisaul)
        {
            _visualTarget = new VisualTarget(hostVisaul);
            base.AddSource();
        }

        protected override CompositionTarget GetCompositionTargetCore()
        {
            return _visualTarget;
        }

        public override bool IsDisposed
        {
            get { return _isDisposed; }
        }

        public override Visual RootVisual
        {
            get
            {
                return _visualTarget.RootVisual;
            }
            set
            {
                var oldVisual = _visualTarget.RootVisual;
                _visualTarget.RootVisual = value;
                base.RootChanged(oldVisual, value);
                if (value is UIElement)
                {
                    var rootElement = value as UIElement;
                    rootElement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    rootElement.Arrange(new Rect(rootElement.DesiredSize));
                }
            }
        }

        public void Dispose()
        {
            base.RemoveSource();
            _isDisposed = true;
        }
    }
}
