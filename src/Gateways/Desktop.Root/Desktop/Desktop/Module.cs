using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Desktop.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EnduranceContestManager.Gateways.Desktop
{
    public class Module : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IInitializerInterface initialier;

        public Module(IRegionManager regionManager, IInitializerInterface initialier)
        {
            this.regionManager = regionManager;
            this.initialier = initialier;
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