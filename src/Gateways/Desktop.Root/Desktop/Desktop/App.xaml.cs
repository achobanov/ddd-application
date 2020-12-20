using EnduranceContestManager.Gateways.Desktop.Core;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;

namespace EnduranceContestManager.Gateways.Desktop
{
    public partial class App : PrismApplication
    {
        private readonly ServiceProvider serviceProvider;
        private readonly IRegionManager regionManager;

        private App()
        {
            var services = DesktopStartup.ConfigureServices();
            this.serviceProvider = services.BuildServiceProvider();

            this.regionManager = regionManager;
        }
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // foreach (var service in services)
            // {
            //     containerRegistry.Register
            //     switch (service.Lifetime)
            //     {
            //         case ServiceLifetime.Singleton:
            //             containerRegistry.RegisterSingleton(service.ServiceType, service.ImplementationType);
            //             break;
            //         case ServiceLifetime.Transient:
            //             containerRegistry.Register(service.ServiceType, service.ImplementationType);
            //             break;
            //         case ServiceLifetime.Scoped:
            //         default:
            //             throw new InvalidOperationException($"Unsupported service lifestyle: {service.Lifetime}");
            //     }
            // }
        }

        protected override Window CreateShell()
        {
            var initializer = this.serviceProvider.GetServices<IInitializerInterface>();
            // Call initializers
            return this.Container.Resolve<ShellWindow>();
            
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<Module>();
        }

        protected override IContainerExtension CreateContainerExtension()
            => ContainerLocator.Current;
    }
}