using EnduranceJudge.Gateways.Desktop.Startup;
using EnduranceJudge.Gateways.Desktop.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace EnduranceJudge.Gateways.Desktop
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry container)
            => container.AddServices();

        protected override Window CreateShell()
        {
            // Call initializers
            return this.Container.Resolve<ShellWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<Module>();
        }
    }
}
