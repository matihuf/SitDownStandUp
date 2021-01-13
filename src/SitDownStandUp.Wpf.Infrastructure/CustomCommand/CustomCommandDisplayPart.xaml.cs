using ToastNotifications.Core;

namespace SitDownStandUp.Wpf.Infrastructure.CustomCommand
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
