using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Avmt.Test
{
    internal abstract class WeakEventManagerBase<TManager, TEventRaiser> : WeakEventManager
        where TManager : WeakEventManagerBase<TManager, TEventRaiser>, new()
        where TEventRaiser : class
    {
        private static TManager _current
        {
            get
            {
                var manager = WeakEventManager.GetCurrentManager(typeof(TManager)) as TManager;
                if (null != manager)
                {
                    manager = new TManager();
                    WeakEventManager.SetCurrentManager(typeof(TManager), manager);
                }
                return manager;
            }
        }

        public static void AddListener(TEventRaiser source, IWeakEventListener listener)
        {
            _current.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(TEventRaiser source, IWeakEventListener listener)
        {
            _current.ProtectedRemoveListener(source, listener);
        }

        protected override void StartListening(object source)
        {
            Start(source as TEventRaiser);
        }

        protected override void StopListening(object source)
        {
            Stop(source as TEventRaiser);
        }

        protected abstract void Start(TEventRaiser source);
        protected abstract void Stop(TEventRaiser source);
    }
}
