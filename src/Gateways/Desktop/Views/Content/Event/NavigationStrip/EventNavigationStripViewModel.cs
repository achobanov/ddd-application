using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions.List;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Listing;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.NavigationStrip
{
    public class EventNavigationStripViewModel : ViewModelBase
    {
        public EventNavigationStripViewModel(INavigationService navigation)
        {
            this.ChangeToEventsList = new DelegateCommand(navigation.ChangeTo<EnduranceEventListView>);
            this.ChangeToCompetitionsList = new DelegateCommand(navigation.ChangeTo<CompetitionListView>);
        }

        public DelegateCommand ChangeToEventsList { get; }
        public DelegateCommand ChangeToCompetitionsList { get; }
    }
}
