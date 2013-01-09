using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Avmt.Test
{
    /// <summary>
    /// Interaction logic for AdornerTest.xaml
    /// </summary>
    public partial class AdornerTest : UserControl
    {
        public AdornerTest()
        {
            InitializeComponent();
        }

        private void DoBlockingTask(object sender, RoutedEventArgs e)
        {
            busy.IsBusying = true;
            Thread.Sleep(5000);
            busy.IsBusying = false;
        }

        private void DoBlockingTaskWithFadeOut(object sender, RoutedEventArgs e)
        {
            // set the FadeTime to 0 seconds to ensure that it is as immediate as possible
            busy.FadeTime = TimeSpan.Zero;
            busy.IsBusying = true;
            // in order for setting the opacity to take effect, you have to delay the task slightly to ensure WPF has time to process the updated visual
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Thread.Sleep(5000);
                busy.IsBusying = false;
                busy.ClearValue(BusyIndicator.FadeTimeProperty);
            }), DispatcherPriority.Background);
        }

        private void DoBackgroundTask(object sender, RoutedEventArgs e)
        {
            busy.IsBusying = true;
            var task = Task.Factory.StartNew(() => Thread.Sleep(5000));
            task.ContinueWith(r => busy.IsBusying = false, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
