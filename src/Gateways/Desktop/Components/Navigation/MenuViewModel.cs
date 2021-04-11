using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.Import;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.Core;
using Prism.Commands;
using Prism.Regions;

namespace EnduranceJudge.Gateways.Desktop.Components.Navigation
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IRegionManager regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigateToFirst = new DelegateCommand(this.GoTo<First>);
            this.NavigateToSecond = new DelegateCommand(this.GoTo<Second>);
            this.NavigateToImport = new DelegateCommand(this.GoTo<Import>);
        }

        public DelegateCommand NavigateToFirst { get; }
        public DelegateCommand NavigateToSecond { get; }
        public DelegateCommand NavigateToImport { get; }

        private void GoTo<T>()
        {
            var viewName = typeof(T).Name;
            this.regionManager.RequestNavigate(Regions.Content, viewName);
        }
    }
}
