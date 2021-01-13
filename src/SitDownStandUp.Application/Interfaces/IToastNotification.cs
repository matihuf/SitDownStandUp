using System.Windows.Input;

namespace SitDownStandUp.Application.Interfaces
{
    public interface IToastNotification
    {
        void Show(string message, ICommand confirmationCommand, ICommand declineCommand);
        void Close();
    }
}
