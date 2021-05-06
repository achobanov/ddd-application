using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.PrintExample;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.Core;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Commands;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService navigation;

        public MenuViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            this.NavigateToFirst = new DelegateCommand(this.navigation.NavigateTo<First>);
            this.NavigateToSecond = new DelegateCommand(this.navigation.NavigateTo<Second>);
            this.NavigateToImport = new DelegateCommand(this.navigation.NavigateTo<Import>);
            this.NavigateToPrintExample = new DelegateCommand(this.navigation.NavigateTo<PrintExample>);
        }

        public DelegateCommand NavigateToFirst { get; }
        public DelegateCommand NavigateToSecond { get; }
        public DelegateCommand NavigateToImport { get; }
        public DelegateCommand NavigateToPrintExample { get; }
    }
}
