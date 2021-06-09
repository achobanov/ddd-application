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
    public abstract class ListViewModelBase<TApplicationCommand, TCreateView, TUpdateView> : ViewModelBase
        where TApplicationCommand : IRequest<IEnumerable<ListItemModel>>, new()
        where TCreateView : IView
        where TUpdateView : IView
    {
        protected ListViewModelBase(IApplicationService application, INavigationService navigation)
        {
            this.Navigation = navigation;
            this.ChangeToCreate = new DelegateCommand(this.ChangeToCreateAction);
            this.Application = application;
        }

        protected INavigationService Navigation { get; }
        protected IApplicationService Application { get; }

        protected ObservableCollection<ListItemViewModel> ListItems { get; }
            = new (Enumerable.Empty<ListItemViewModel>());

        public DelegateCommand ChangeToCreate { get; }

        public override void OnNavigatedTo(Prism.Regions.NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            base.OnNavigatedTo(navigationContext);

            this.LoadEvents();
        }

        private async Task LoadEvents()
        {
            var getEventsList = new TApplicationCommand();
            var eventsList = await this.Application.Execute(getEventsList);

            var viewModels = eventsList
                .Select(this.ToViewModeL)
                .ToList();

            this.ListItems.Clear();
            this.ListItems.AddRange(viewModels);
        }

        private ListItemViewModel ToViewModeL(ListItemModel model)
        {
            var command = new DelegateCommand<int?>(this.ChangeToUpdateAction);
            return new ListItemViewModel(model.Id, model.Name, command);
        }

        protected virtual void ChangeToCreateAction()
        {
            this.Navigation.ChangeTo<TCreateView>();
        }

        protected virtual void ChangeToUpdateAction(int? id)
        {
            this.Navigation.ChangeTo<TUpdateView>(id.Value);
        }
    }
}
