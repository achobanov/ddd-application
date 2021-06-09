using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Events;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public class PrincipalFormBase<TSave> : CreateFormBase<TSave>
        where TSave : IRequest
    {
        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigation;

        public PrincipalFormBase(
            IApplicationService application,
            IEventAggregator eventAggregator,
            INavigationService navigation)
            : base(application)
        {
            this.eventAggregator = eventAggregator;
            this.navigation = navigation;
        }

        protected void AddDependent<T>(Action<T> action)
            where T : DependantFormBase
        {
            this.eventAggregator
                .GetEvent<FormCreateEvent<T>>()
                .Subscribe(action);
        }

        protected void ChangeTo<T>()
            where T : IView
        {
            this.navigation.ChangeTo<T>();
        }
    }
}
