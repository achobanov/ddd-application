using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(INavigationService navigation, IApplicationService application) : base(application)
        {
            this.NavigateToFirst = new DelegateCommand(navigation.NavigateTo<First>);
            this.NavigateToSecond = new DelegateCommand(navigation.NavigateTo<Second>);
            this.NavigateToImport = new DelegateCommand(navigation.NavigateTo<Import>);
            this.NavigateToPrintExample = new DelegateCommand(navigation.NavigateTo<PrintExample>);
        }

        public DelegateCommand NavigateToFirst { get; }
        public DelegateCommand NavigateToSecond { get; }
        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToPrintExample { get; }
    }
}
