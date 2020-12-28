using EnduranceContestManager.Core.Contracts;
using EnduranceContestManager.Gateways.Desktop.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EnduranceContestManager.Gateways.Desktop
{
    public class Module : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IDateTime dateTime;

        public Module(IRegionManager regionManager, IDateTime dateTime)
        {
            this.regionManager = regionManager;
            this.dateTime = dateTime;
        }
        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}