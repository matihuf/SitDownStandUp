using SitDownStandUp.Application.Interfaces;
using SitDownStandUp.Wpf.Infrastructure.CustomCommand;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime.Clear;

namespace SitDownStandUp.Wpf
{
    public class WpfToastNotification : IToastNotification
    {
        private readonly Notifier _notifier;

        public WpfToastNotification(Notifier notifier)
        {
            _notifier = notifier;
        }

        public void Close()
        {
            _notifier.ClearMessages(new ClearAll());

        }

        public void Show(string message, ICommand confirmationCommand, ICommand declineCommand)
        {
            _notifier.Notify(() => new CustomCommandNotification(message, confirmationCommand, declineCommand));
        }
    }
}
