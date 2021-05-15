using EnduranceJudge.Application.Events.Queries.GetEventsList;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.List
{
    public class EnduranceEventListViewModel : ViewModelBase
    {
        private readonly INavigationService navigation;

        public EnduranceEventListViewModel(INavigationService navigation, IApplicationService application)
            : base (application)
        {
            this.navigation = navigation;
        }

        public ObservableCollection<ListItemViewModel> EnduranceEvents { get; }
            = new (Enumerable.Empty<ListItemViewModel>());

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (this.EnduranceEvents.Any())
            {
                return;
            }

            this.LoadEvents();
        }

        private async Task LoadEvents()
        {
            var getEventsList = new GetEventsList();

            var eventsList = await this.Application.Execute(getEventsList);
            var viewModels = eventsList
                .Select(e =>
                {
                    var command = new DelegateCommand<int?>(this.NavigateToUpdate);
                    return new ListItemViewModel(e.Id, e.Name, command);
                })
                .ToList();

            this.EnduranceEvents.AddRange(viewModels);
        }

        private void NavigateToUpdate(int? id)
        {
            this.navigation.ChangeTo<EnduranceEventView>(id.Value);
        }
    }
}
