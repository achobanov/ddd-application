using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class CreateFormBase<TSave> : ViewModelBase,
        IMapTo<TSave>
        where TSave : IRequest
    {
        protected CreateFormBase(IApplicationService application) : base(application)
        {
            this.Create = new AsyncCommand(this.CreateAction);
        }

        public DelegateCommand Create { get; }
        protected virtual async Task CreateAction()
        {
            var command = this.Map<TSave>();

            await this.Application.Execute(command);
        }
    }
}
