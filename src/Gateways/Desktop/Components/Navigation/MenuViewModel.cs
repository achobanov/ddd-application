using EnduranceJudge.Gateways.Desktop.Components.Content.Event;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Commands;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(INavigationService navigation, IMediator mediator) : base(mediator)
        {
            this.NavigateToImport = new DelegateCommand(navigation.NavigateTo<Import>);
            this.NavigateToPrintExample = new DelegateCommand(navigation.NavigateTo<PrintExample>);
            this.NavigateToCreateEvent = new DelegateCommand(navigation.NavigateTo<Event>);
            this.NavigateToUpdateEvent = new DelegateCommand(() => navigation.NavigateTo<Event>(4));
        }

        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToPrintExample { get; }
        public DelegateCommand NavigateToCreateEvent { get; }
        public DelegateCommand NavigateToUpdateEvent { get; }
    }
}
