using EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Listing;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.NavigationStrip;
using EnduranceJudge.Gateways.Desktop.Views.Content.Import;
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
            this.ChangeTo<ImportView>();
            this.ClearRegion(Regions.SubNavigation);
        }

        public void NavigateToEvent()
        {
            this.ChangeTo<EnduranceEventListView>();
            this.ChangeTo<EventNavigationStripView>(Regions.SubNavigation);
        }
    }
}
