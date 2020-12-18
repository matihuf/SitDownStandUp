using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.ViewModels;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace SitDownStandUp
{
    public static class DependencyInjection
    {
        public static IServiceCollection Inject(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            services.AddTransient<DispatcherTimer>();
            services.AddTransient(t => new Notifier(cfg =>
            {
                cfg.LifetimeSupervisor = new CountBasedLifetimeSupervisor(MaximumNotificationCount.FromCount(1));
                cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomRight, 10, 10);
            }));
            return services;
        }
    }
}
