using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToastNotifications.Core;

namespace SitDownStandUp.Wpf.Infrastructure.CustomCommand
{
    public class CustomCommandNotification : NotificationBase, INotifyPropertyChanged
    {
        private CustomCommandDisplayPart _displayPart;
        public ICommand ConfirmCommand { get; set; }
        public ICommand DeclineCommand { get; set; }

        public CustomCommandNotification(string message, ICommand confirmationCommand, ICommand declineCommand, MessageOptions messageOptions = null)
            : base(message, messageOptions)
        {
            Message = message;
            ConfirmCommand = confirmationCommand;
            DeclineCommand = declineCommand;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new CustomCommandDisplayPart(this));

        #region binding properties

        private string _message;

        public new string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
