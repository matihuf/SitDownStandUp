using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SitDownStandUp.Application.Interfaces;
using SitDownStandUp.Models.Enums;
using System;

namespace SitDownStandUp.Application.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDispatcherTimer _dispatcherTimer;
        private readonly IToastNotification _toastNotification;
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

        public MainViewModel(IDispatcherTimer dispatcherTimer, IToastNotification toastNotification)
        {
            if (IsInDesignMode)
                return;

            _currentPositionType = PositionType.Sitting;
            TimeLeft = (int)_currentPositionType;
            CurrentPositionTime = (int)_currentPositionType;
            _toastNotification = toastNotification;

            _dispatcherTimer = dispatcherTimer;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                TimeLeft -= _dispatcherTimer.Interval.Seconds;
                CurrentProgress++;
            }
            else
            {
                _dispatcherTimer.Stop();
                CurrentProgress = 0;
                _toastNotification.Close();
                _toastNotification.Show($"Zmiana pozycji z {_currentPositionType}", new RelayCommand(Confirmation()), new RelayCommand(Decline()));
            }
        }

        private Action Decline()
        {
            return () =>
            {
                TimeLeft = (int)_currentPositionType;
                _dispatcherTimer.Start();
                _toastNotification.Close();
            };
        }

        private Action Confirmation()
        {
            return () =>
            {
                if (_currentPositionType == PositionType.Sitting)
                    _currentPositionType = PositionType.Standing;
                else
                    _currentPositionType = PositionType.Sitting;

                TimeLeft = (int)_currentPositionType;
                CurrentPositionTime = (int)_currentPositionType;
                _dispatcherTimer.Start();
                _toastNotification.Close();
            };
        }
    }
}
