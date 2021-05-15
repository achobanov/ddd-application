using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class ListVIewModelBase<TApplicationCommand> : ViewModelBase
        where TApplicationCommand : IRequest<IEnumerable<ListItemModel>>, new()
    {
        protected ListVIewModelBase(IApplicationService application) : base(application)
        {
        }

        protected ObservableCollection<ListItemViewModel> ListItems { get; }
            = new (Enumerable.Empty<ListItemViewModel>());

        public override void OnNavigatedTo(Prism.Regions.NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            base.OnNavigatedTo(navigationContext);
            if (this.ListItems.Any())
            {
                return;
            }

            this.LoadEvents();
        }

        private async Task LoadEvents()
        {
            var getEventsList = new TApplicationCommand();

            var eventsList = await this.Application.Execute(getEventsList);
            var viewModels = eventsList
                .Select(e =>
                {
                    var command = new DelegateCommand<int?>(this.NavigateToUpdate);
                    return new ListItemViewModel(e.Id, e.Name, command);
                })
                .ToList();

            this.ListItems.AddRange(viewModels);
        }

        protected abstract void NavigateToUpdate(int? id);
    }
}
