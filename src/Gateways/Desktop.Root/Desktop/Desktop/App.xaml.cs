using EnduranceContestManager.Gateways.Desktop.Core;
using EnduranceContestManager.Gateways.Desktop.Core.DI;
using EnduranceContestManager.Gateways.Desktop.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace EnduranceContestManager.Gateways.Desktop
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var services = new ServiceCollection();
            DesktopStartup.ConfigureServices(services);
        }

        protected override Window CreateShell()
        {
            // Call initializers
            return this.Container.Resolve<ShellWindow>();
        }
    }
}