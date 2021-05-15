using EnduranceJudge.Application.Events.Queries.GetEventsList;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Core.ViewModels;
using EnduranceJudge.Gateways.Desktop.Services;
using System.Collections.ObjectModel;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.List
{
    public class EnduranceEventListViewModel : ListVIewModelBase<GetEventsList>
    {
        private readonly INavigationService navigation;

        public EnduranceEventListViewModel(INavigationService navigation, IApplicationService application)
            : base (application)
        {
            this.navigation = navigation;
        }

        public ObservableCollection<ListItemViewModel> EnduranceEvents => this.ListItems;

        protected override void NavigateToUpdate(int? id)
        {
            this.navigation.ChangeTo<EnduranceEventView>(id.Value);
        }
    }
}
