using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avmt.Test
{
    internal class IsVisibleChangedEventArgs : EventArgs
    {
        private bool _isVisible;
        public bool IsVisible { get { return _isVisible; } }

        public IsVisibleChangedEventArgs(bool isVisible)
        {
            _isVisible = isVisible;
        }
    }
}
