using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.Application.Interfaces;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace SitDownStandUp.Wpf.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<DispatcherTimer>();
            services.AddTransient<IDispatcherTimer, WpfDispatcherTimer>();
            services.AddTransient(t => new Notifier(cfg =>
            {
                cfg.LifetimeSupervisor = new CountBasedLifetimeSupervisor(MaximumNotificationCount.FromCount(1));
                cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomRight, 10, 10);
            }));
            services.AddTransient<IToastNotification, WpfToastNotification>();
            return services;
        }
    }
}
