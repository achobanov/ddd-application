using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Commands;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class PrincipalFormBase<TCommand, TUpdateModel> : FormBase,
        IMapTo<TCommand>
        where TCommand : IRequest<TUpdateModel>
    {
        protected PrincipalFormBase(IApplicationService application, INavigationService navigation)
        {
            this.Application = application;
            this.Navigation = navigation;

            this.Submit = new AsyncCommand(this.SubmitAction);
        }

        protected IApplicationService Application { get; }
        protected INavigationService Navigation { get; }

        public DelegateCommand Submit { get; }

        protected Action GetCreateDelegate<T>(Action<object> action)
            where T : IView
        {
            return () => this.Navigation.ChangeTo<T>(action);
        }

        protected Action GetUpdateDelegate<TView>(object data, Action<object> action)
            where TView : IView
        {
            return () => this.Navigation.ChangeTo<TView>(data, action);
        }

        protected virtual async Task SubmitAction()
        {
            var command = this.Map<TCommand>();

            var result = await this.Application.Execute(command);

            this.MapFrom(result);
        }
    }
}
