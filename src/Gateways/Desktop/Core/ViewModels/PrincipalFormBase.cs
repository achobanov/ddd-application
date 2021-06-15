using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class PrincipalFormBase<TCommand> : FormBase,
        IMapTo<TCommand>
        where TCommand : IRequest
    {
        protected PrincipalFormBase(IApplicationService application, INavigationService navigation)
        {
            this.Application = application;
            this.Navigation = navigation;
        }

        protected IApplicationService Application { get; }
        protected INavigationService Navigation { get; }

        protected Action GetCreateDelegate<T>()
            where T : IView
        {
            return this.Navigation.ChangeTo<T>;
        }

        protected Action GetUpdateDelegate<TView>(object data, Action<object> action)
            where TView : IView
        {
            return () => this.Navigation.ChangeTo<TView>(data, action);
        }

        protected override async Task SubmitAction()
        {
            var command = this.Map<TCommand>();

            await this.Application.Execute(command);
        }
    }
}
