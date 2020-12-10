using GalaSoft.MvvmLight;
using SitDownStandUp.CustomCommand;
using SitDownStandUp.Models.Enums;
using System;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime.Clear;

namespace SitDownStandUp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly Notifier _notifier;
        private PositionType _currentPositionType;
        private int _timeLeft;

        private string timeLeft;
        public string TimeLeft
        {
            get { return timeLeft; }
            set
            {
                if (value != timeLeft)
                {
                    timeLeft = value;
                    RaisePropertyChanged("timeLeft");
                }
            }
        }

        public MainViewModel(DispatcherTimer dispatcherTimer, Notifier notifier)
        {
            _currentPositionType = PositionType.Sitting;
            _timeLeft = (int)_currentPositionType;
            _notifier = notifier;

            _dispatcherTimer = dispatcherTimer;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            _dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= _dispatcherTimer.Interval.Seconds;
                TimeLeft = $"{_timeLeft} minuty";
            }
            else
            {
                _dispatcherTimer.Stop();
                _notifier.ClearMessages(new ClearAll());
                _notifier.ShowCustomCommand($"Zmiana pozycji z {_currentPositionType}", Confirmation(), Decline());
            }
        }

        private Action<CustomCommandNotification> Decline()
        {
            return n =>
            {
                _timeLeft = (int)_currentPositionType;
                _dispatcherTimer.Start();
                n.Close();
            };
        }

        private Action<CustomCommandNotification> Confirmation()
        {
            return n =>
            {
                if (_currentPositionType == PositionType.Sitting)
                    _currentPositionType = PositionType.Standing;
                else
                    _currentPositionType = PositionType.Sitting;

                _timeLeft = (int)_currentPositionType;
                _dispatcherTimer.Start();
                n.Close();
            };
        }
    }
}
