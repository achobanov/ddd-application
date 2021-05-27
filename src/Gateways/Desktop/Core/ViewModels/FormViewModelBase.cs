using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Enums;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class FormViewModelBase<TGetCommand, TSaveCommand, TUpdateModel> : ViewModelBase,
        IMapFrom<TUpdateModel>,
        IMapTo<TSaveCommand>
        where TGetCommand : IIdentifiableRequest<TUpdateModel>, new()
        where TSaveCommand : IRequest
    {
        protected FormViewModelBase(IApplicationService application) : base(application)
        {
            this.Save = new AsyncCommand(this.SaveAction);
        }

        protected FormOperation OperationMode { get; private set; }

        public DelegateCommand Save { get; }
        public bool HasSaved { get; private set; }

        protected virtual async Task SaveAction()
        {
            var command = this.Map<TSaveCommand>();

            await this.Application.Execute(command);
            this.HasSaved = true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            this.OperationMode = navigationContext.GetOperationMode();

            if (this.OperationMode == FormOperation.Update)
            {
                var id = navigationContext.GetId();
                if (!id.HasValue)
                {
                    throw new InvalidOperationException(
                        "Update operation requires Id navigational parameter");
                }

                this.Load(id.Value);
            }
        }

        private async Task Load(int id)
        {
            var command = new TGetCommand
            {
                Id = id
            };

            var enduranceEvent = await this.Application.Execute(command);

            this.MapFrom(enduranceEvent);
        }
    }
}
