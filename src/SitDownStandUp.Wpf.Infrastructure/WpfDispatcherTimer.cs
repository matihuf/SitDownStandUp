using SitDownStandUp.Application.Interfaces;
using System;
using System.Windows.Threading;

namespace SitDownStandUp.Wpf
{
    public class WpfDispatcherTimer : IDispatcherTimer
    {
        public event EventHandler Tick;
        private readonly DispatcherTimer _dispatcherTimer;

        public WpfDispatcherTimer(DispatcherTimer dispatcherTimer)
        {
            _dispatcherTimer = dispatcherTimer;
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
        }

        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(sender, e);
        }

        public TimeSpan Interval
        {
            get => _dispatcherTimer.Interval;
            set => _dispatcherTimer.Interval = value;
        }

        public void Start()
        {
            _dispatcherTimer.Start();
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
        }
    }
}
