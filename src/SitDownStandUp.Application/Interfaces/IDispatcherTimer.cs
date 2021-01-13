using System;

namespace SitDownStandUp.Application.Interfaces
{
    public interface IDispatcherTimer
    {
        TimeSpan Interval { get; set; }
        event EventHandler Tick;

        void Start();
        void Stop();
    }
}
