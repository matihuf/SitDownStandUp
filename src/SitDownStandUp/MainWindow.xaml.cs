using System.Windows;

namespace SitDownStandUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly Notifier _notifier;
        //private readonly DispatcherTimer _dispatcherTimer;
        //private readonly PositionType _currentPositionType;
        //private readonly int _timeLeft;

        public MainWindow()
        {
            InitializeComponent();
        }
        //    Unloaded += OnUnload;
        //    _currentPositionType = PositionType.Sitting;
        //    _timeLeft = (int)_currentPositionType;
        //    _notifier = new Notifier(cfg =>
        //    {
        //        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(TimeSpan.FromMinutes(5), MaximumNotificationCount.FromCount(1));
        //        cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomRight, 10, 10);
        //    });

        //    _dispatcherTimer = new DispatcherTimer();
        //    _dispatcherTimer.Tick += DispatcherTimer_Tick;
        //    _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        //    _dispatcherTimer.Start();

        //}

        //private void DispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    if (_timeLeft > 0)
        //    {
        //        _timeLeft -= _dispatcherTimer.Interval.Seconds;
        //        timeLabel.Content = $"{_timeLeft} minuty";
        //    }
        //    else
        //    {
        //        _dispatcherTimer.Stop();
        //        _notifier.ClearMessages(new ClearAll());
        //        _notifier.ShowCustomCommand($"Zmiana pozycji z {_currentPositionType}", Confirmation(), Decline());
        //    }
        //}

        //private Action<CustomCommandNotification> Decline()
        //{
        //    return n =>
        //    {
        //        _timeLeft = (int)_currentPositionType;
        //        _dispatcherTimer.Start();
        //        n.Close();
        //    };
        //}

        //private Action<CustomCommandNotification> Confirmation()
        //{
        //    return n =>
        //    {
        //        if (_currentPositionType == PositionType.Sitting)
        //            _currentPositionType = PositionType.Standing;
        //        else
        //            _currentPositionType = PositionType.Sitting;

        //        _timeLeft = (int)_currentPositionType;
        //        _dispatcherTimer.Start();
        //        n.Close();
        //    };
        //}

        //private void OnUnload(object sender, RoutedEventArgs e)
        //{
        //    _notifier.Dispose();
        //    _dispatcherTimer.Stop();
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
