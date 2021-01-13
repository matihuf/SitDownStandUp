using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.Application.ViewModels;

namespace SitDownStandUp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            return services;
        }
    }
}
