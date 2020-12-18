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
        public int TimeLeft
        {
            get { return _timeLeft; }
            private set
            {
                if (value != _timeLeft)
                {
                    _timeLeft = value;
                    RaisePropertyChanged("TimeLeft");
                }
            }
        }

        private double _currentProgress;
        public double CurrentProgress
        {
            get { return _currentProgress; }
            private set
            {
                if (value != _currentProgress)
                {
                    _currentProgress = value;
                    RaisePropertyChanged("CurrentProgress");
                }
            }
        }

        private int _currentPositionTime;
        public int CurrentPositionTime
        {
            get { return _currentPositionTime; }
            private set
            {
                if (value != _currentPositionTime)
                {
                    _currentPositionTime = value;
                    RaisePropertyChanged("CurrentPositionTime");
                }
            }
        }

        public MainViewModel(DispatcherTimer dispatcherTimer, Notifier notifier)
        {
            if (IsInDesignMode)
                return;

            _currentPositionType = PositionType.Sitting;
            TimeLeft = (int)_currentPositionType;
            CurrentPositionTime = (int)_currentPositionType;
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
                TimeLeft -= _dispatcherTimer.Interval.Minutes;
                CurrentProgress++;
            }
            else
            {
                _dispatcherTimer.Stop();
                CurrentProgress = 0;
                _notifier.ClearMessages(new ClearAll());
                _notifier.ShowCustomCommand($"Zmiana pozycji z {_currentPositionType}", Confirmation(), Decline());
            }
        }

        private Action<CustomCommandNotification> Decline()
        {
            return n =>
            {
                TimeLeft = (int)_currentPositionType;
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

                TimeLeft = (int)_currentPositionType;
                CurrentPositionTime = (int)_currentPositionType;
                _dispatcherTimer.Start();
                n.Close();
            };
        }
    }
}
