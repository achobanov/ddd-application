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
    public abstract class PrincipalFormBase<TCommand> : FormBase,
        IMapTo<TCommand>
        where TCommand : IRequest
    {
        private readonly IEventAggregator eventAggregator;

        protected PrincipalFormBase(
            IApplicationService application,
            IEventAggregator eventAggregator,
            INavigationService navigation)
        {
            this.Application = application;
            this.eventAggregator = eventAggregator;
            this.Navigation = navigation;
        }

        protected IApplicationService Application { get; }
        protected INavigationService Navigation { get; }

        protected Action GetCreateDelegate<T>()
            where T : IView
        {
            return this.Navigation.ChangeTo<T>;
        }

        protected Action GetUpdateDelegate<T>(object data, Action action)
            where T : IView
        {
            return () => this.Navigation.ChangeTo<T>(data, action);
        }

        protected override async Task SubmitAction()
        {
            var command = this.Map<TCommand>();

            await this.Application.Execute(command);
        }
    }
}
