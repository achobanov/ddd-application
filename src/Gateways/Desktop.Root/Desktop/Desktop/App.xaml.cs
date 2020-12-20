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
            
        }

        protected override Window CreateShell()
            => this.Container.Resolve<ShellWindow>();
    }
}