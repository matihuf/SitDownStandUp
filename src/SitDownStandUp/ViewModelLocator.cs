using Microsoft.Extensions.DependencyInjection;
using SitDownStandUp.ViewModels;
using System;

namespace SitDownStandUp
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            _serviceProvider = new ServiceCollection()
               .Inject()
               .BuildServiceProvider();
        }

        public MainViewModel Main
        {
            get { return _serviceProvider.GetRequiredService<MainViewModel>(); }
        }
    }
}
