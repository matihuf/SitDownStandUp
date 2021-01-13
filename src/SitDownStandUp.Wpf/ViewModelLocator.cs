using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.Application;
using SitDownStandUp.Application.ViewModels;
using SitDownStandUp.Wpf.Infrastructure;
using System;

namespace SitDownStandUp.Wpf
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            _serviceProvider = new ServiceCollection()
               .AddInfrastructure()
               .AddApplication()
               .BuildServiceProvider();
        }

        public MainViewModel Main
        {
            get { return _serviceProvider.GetRequiredService<MainViewModel>(); }
        }
    }
}
