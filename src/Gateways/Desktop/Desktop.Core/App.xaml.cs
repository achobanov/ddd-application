using EnduranceContestManager.Gateways.Desktop.Core.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace EnduranceContestManager.Gateways.Desktop.Core
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