using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using MediatR;
using Prism.Commands;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class RootFormBase<TCommand, TUpdateModel> : FormBase,
        IMapTo<TCommand>
        where TCommand : IRequest<TUpdateModel>
    {
        protected RootFormBase(IApplicationService application, INavigationService navigation) : base(navigation)
        {
            this.Application = application;

            this.Submit = new AsyncCommand(this.SubmitAction);
        }

        protected IApplicationService Application { get; }

        public DelegateCommand Submit { get; }
        protected virtual async Task SubmitAction()
        {
            var command = this.Map<TCommand>();

            var result = await this.Application.Execute(command);

            this.MapFrom(result);
        }
    }
}
