using ToastNotifications.Core;

namespace SitDownStandUp.CustomCommand
{
    /// <summary>
    /// Interaction logic for CustomCommandDisplayPart.xaml
    /// </summary>
    public partial class CustomCommandDisplayPart : NotificationDisplayPart
    {
        public CustomCommandDisplayPart(CustomCommandNotification notification)
        {
            InitializeComponent();
            Bind(notification);
        }
    }
}
