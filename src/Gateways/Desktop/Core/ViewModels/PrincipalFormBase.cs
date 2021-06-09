using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Events;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class PrincipalFormBase<TSave> : FormBase,
        IMapTo<TSave>
        where TSave : IRequest
    {
        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigation;

        protected PrincipalFormBase(
            IApplicationService application,
            IEventAggregator eventAggregator,
            INavigationService navigation)
        {
            this.Application = application;
            this.eventAggregator = eventAggregator;
            this.navigation = navigation;
        }

        protected IApplicationService Application { get; }

        protected void AddDependent<T>(Action<T> action)
            where T : DependantFormBase
        {
            this.eventAggregator
                .GetEvent<DependantFormSubmitEvent<T>>()
                .Subscribe(action);
        }

        protected void ChangeTo<T>()
            where T : IView
        {
            this.navigation.ChangeTo<T>();
        }

        protected override async Task SubmitAction()
        {
            var command = this.Map<TSave>();

            await this.Application.Execute(command);
        }
    }
}
