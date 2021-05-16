using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Events.Commands.SaveEnduranceEvent;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Commands;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using MediatR;
using Prism.Commands;
using Prism.Regions;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public class FormViewModelBase<TGetCommand, TSaveCommand, TUpdateModel> : ViewModelBase,
        IMapFrom<TUpdateModel>,
        IMapTo<TSaveCommand>
        where TGetCommand : IIdentifiableRequest<TUpdateModel>, new()
        where TSaveCommand : IRequest
    {
        public FormViewModelBase(IApplicationService application) : base(application)
        {
            this.Save = new AsyncCommand(this.SaveAction);
        }

        public DelegateCommand Save { get; }
        public bool HasSaved { get; private set; }

        private async Task SaveAction()
        {
            var command = this.Map<SaveEnduranceEvent>();

            await this.Application.Execute(command);
            this.HasSaved = true;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var enduranceEventId = navigationContext.GetId();
            if (enduranceEventId.HasValue)
            {
                this.Load(enduranceEventId.Value);
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
