using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Create
{
    public class CreateEnduranceEventViewModel
        : EnduranceEventFormBase<CreateEnduranceEvent, EnduranceEventForUpdateModel>
    {
        public CreateEnduranceEventViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
        }
    }
}
