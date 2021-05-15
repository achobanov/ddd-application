using EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents.List;
using EnduranceJudge.Gateways.Desktop.Components.Content.Event.NavigationStrip;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Core.Services.Implementations;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Services.Implementations
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public NavigationService(IRegionManager regionManager) : base(regionManager)
        {
        }

        public void NavigateToImport()
        {
            this.ChangeTo<Import>();
            this.ClearRegion(Regions.SubNavigation);
        }

        public void NavigateToEvent()
        {
            this.ChangeTo<EnduranceEventList>();
            this.ChangeTo<EventNavigationStrip>(Regions.SubNavigation);
        }
    }
}
