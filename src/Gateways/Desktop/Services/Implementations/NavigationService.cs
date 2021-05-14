using EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents;
using EnduranceJudge.Gateways.Desktop.Components.Content.Event.NavigationStrip;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Core.Services.Implementations;
using Prism.Events;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Services.Implementations
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public NavigationService(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(regionManager, eventAggregator)
        {
        }

        public void NavigateToImport()
        {
            this.ChangeTo<Import>(Regions.Content);
            this.ClearRegion(Regions.SubNavigation);
        }

        public void NavigateToEvent()
        {
            this.ChangeTo<EnduranceEvent>(Regions.Content);
            this.ChangeTo<EventNavigationStrip>(Regions.SubNavigation);
        }
    }
}
