using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class ListViewModelBase<TApplicationCommand, TView> : ViewModelBase
        where TApplicationCommand : IRequest<IEnumerable<ListItemModel>>, new()
        where TView : IView
    {
        protected ListViewModelBase(IApplicationService application, INavigationService navigation) : base(application)
        {
            this.Navigation = navigation;
            this.ChangeToCreate = new DelegateCommand(this.ChangeToCreateAction);
        }

        protected INavigationService Navigation { get; }

        protected ObservableCollection<ListItemViewModel> ListItems { get; }
            = new (Enumerable.Empty<ListItemViewModel>());

        public DelegateCommand ChangeToCreate { get; }

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
                .Select(this.ToViewModeL)
                .ToList();

            this.ListItems.AddRange(viewModels);
        }

        private ListItemViewModel ToViewModeL(ListItemModel model)
        {
            var command = new DelegateCommand<int?>(this.ChangeToUpdateAction);
            return new ListItemViewModel(model.Id, model.Name, command);
        }

        protected virtual void ChangeToCreateAction()
        {
            this.Navigation.ChangeTo<TView>();
        }

        protected virtual void ChangeToUpdateAction(int? id)
        {
            this.Navigation.ChangeTo<TView>(id.Value);
        }
    }
}
