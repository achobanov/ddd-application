using EnduranceJudge.Application.Events.Queries.GetEventsList;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Components.Content.Event.EnduranceEvents.List
{
    public class Kur : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;

        public Kur(
            IApplicationService application,
            IEventAggregator eventAggregator) : base (application)
        {
            this.eventAggregator = eventAggregator;
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
                    var command = new DelegateCommand<int?>(this.RequestNavigateToUpdate);
                    return new ListItemViewModel(e.Id, e.Name, command);
                })
                .ToList();

            this.EnduranceEvents.AddRange(viewModels);
        }

        private void RequestNavigateToUpdate(int? id)
        {
            this.eventAggregator
                .GetEvent<NavigationEvent<int>>()
                .Publish((new EnduranceEvent(), id.Value));
        }
    }
}
