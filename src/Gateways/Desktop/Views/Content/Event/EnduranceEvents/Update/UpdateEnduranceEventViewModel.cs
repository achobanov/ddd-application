using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Update;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Gateways.Desktop.Core.Extensions;
using EnduranceJudge.Gateways.Desktop.Core.Services;
using EnduranceJudge.Gateways.Desktop.Services;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Views.Content.Event.EnduranceEvents.Update
{
    public class UpdateEnduranceEventViewModel
        : EnduranceEventFormBase<UpdateEnduranceEvent, EnduranceEventForUpdateModel>
    {
        public UpdateEnduranceEventViewModel() : base(null, null)
        {
        }

        public UpdateEnduranceEventViewModel(IApplicationService application, INavigationService navigation)
            : base(application, navigation)
        {
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var id = navigationContext.GetId();

            return this.Id == id;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var id = navigationContext.GetId();
            if (!id.HasValue)
            {
                throw new InvalidOperationException("Update form requires ID parameter.");
            }

            if (this.Id == default)
            {
                this.Load(id.Value);
            }
        }

        private async Task Load(int id)
        {
            var command = new GetEnduranceEvent
            {
                Id = id
            };

            var enduranceEvent = await this.Application.Execute(command);

            this.MapFrom(enduranceEvent);
        }
    }
}
