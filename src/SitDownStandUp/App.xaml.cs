using System.Windows;
using System.Windows.Forms;

namespace SitDownStandUp
{
    public partial class App : System.Windows.Application
    {
        private NotifyIcon _notifyIcon;

        public App()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = SitDownStandUp.Resource1.Icon1;
            _notifyIcon.Visible = true;
            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("MainWindow...").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            _notifyIcon.Dispose();
            _notifyIcon = null;
            Current.Shutdown();
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }
    }
}