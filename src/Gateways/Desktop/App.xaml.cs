using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Desktop.Startup;
using EnduranceJudge.Gateways.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Linq;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry container)
            => container.AddServices();

        protected override Window CreateShell()
        {
            this.InitializeApplication();

            return this.Container.Resolve<ShellWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<Module>();
        }

        private void InitializeApplication()
        {
            var aspNetProvider = this.Container.Resolve<IServiceProvider>();
            var initializers = aspNetProvider.GetServices<IInitializerInterface>();

            foreach (var initializer in initializers.OrderBy(x => x.RunningOrder))
            {
                initializer.Run(aspNetProvider);
            }
        }
    }
}
