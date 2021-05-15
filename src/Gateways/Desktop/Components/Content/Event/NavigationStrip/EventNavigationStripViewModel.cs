using EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents.List;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event.NavigationStrip
{
    public class EventNavigationStripViewModel : ViewModelBase
    {
        public EventNavigationStripViewModel(INavigationService navigation)
        {
            this.ChangeToEventsList = new DelegateCommand(navigation.ChangeTo<EnduranceEventList>);
        }

        public DelegateCommand ChangeToEventsList { get; }
    }
}
