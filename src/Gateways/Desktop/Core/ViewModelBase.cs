using MediatR;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        private readonly IApplicationService application;

        protected IRegionNavigationJournal journal;

        protected ViewModelBase()
        {
        }

        protected ViewModelBase(IApplicationService application)
        {
            this.application = application;
        }

        protected IApplicationService Application
            => this.application
                ?? throw new InvalidOperationException("Application is null. Provide it using the base constructor.");

        public DelegateCommand NavigateForward => new DelegateCommand(() => this.journal?.GoForward());
        public DelegateCommand NavigateBack => new DelegateCommand(() => this.journal?.GoBack());

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.journal = navigationContext.NavigationService.Journal;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
            => true;

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
