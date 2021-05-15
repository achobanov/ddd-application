using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.List;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.NavigationStrip
{
    public class EventNavigationStripViewModel : ViewModelBase
    {
        public EventNavigationStripViewModel(INavigationService navigation)
        {
            this.ChangeToEventsList = new DelegateCommand(navigation.ChangeTo<EnduranceEventListView>);
        }

        public DelegateCommand ChangeToEventsList { get; }
    }
}
