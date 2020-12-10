using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.ViewModels;
using System;
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
            services.AddTransient<Notifier>(t => new Notifier(cfg =>
            {
                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(TimeSpan.FromMinutes(5), MaximumNotificationCount.FromCount(1));
                cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomRight, 10, 10);
            }));
            return services;
        }
    }
}
