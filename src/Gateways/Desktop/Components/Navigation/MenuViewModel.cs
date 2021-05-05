using EnduranceJudge.Gateways.Desktop.Components.Content.Event;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Core;
using MediatR;
using Prism.Commands;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IRegionManager regionManager;

        public MenuViewModel(IRegionManager regionManager, IMediator mediator) : base(mediator)
        {
            this.regionManager = regionManager;
            this.NavigateToImport = new DelegateCommand(this.GoTo<Import>);
            this.NavigateToCreateEvent = new DelegateCommand(this.GoTo<Event>);
            this.NavigateToUpdateEvent = new DelegateCommand(() => this.GoTo<Event>(4));
        }

        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToCreateEvent { get; }
        public DelegateCommand NavigateToUpdateEvent { get; }

        private void GoTo<T>()
            => this.GoTo<T>(null);

        private void GoTo<T>(int? id)
        {
            var parameters = new NavigationParameters();
            if (id.HasValue)
            {
                parameters.Add(nameof(id), id.Value);
            }

            var viewName = typeof(T).Name;
            this.regionManager.RequestNavigate(Regions.Content, viewName, parameters);
        }
    }
}
