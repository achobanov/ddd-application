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
            this.NavigateToEvent = new DelegateCommand(this.GoTo<Event>);
        }

        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToEvent { get; }

        private void GoTo<T>()
        {
            var viewName = typeof(T).Name;
            this.regionManager.RequestNavigate(Regions.Content, viewName);
        }
    }
}
