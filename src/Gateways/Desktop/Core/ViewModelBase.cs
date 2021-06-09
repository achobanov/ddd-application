using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected IRegionNavigationJournal Journal { get; private set; }

        public DelegateCommand NavigateForward => new DelegateCommand(() => this.Journal?.GoForward());
        public DelegateCommand NavigateBack => new DelegateCommand(() => this.Journal?.GoBack());

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Journal = navigationContext.NavigationService.Journal;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
            => true;

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
