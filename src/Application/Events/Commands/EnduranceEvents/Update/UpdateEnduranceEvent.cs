using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Exceptions;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Commands.EnduranceEvents.Create;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Application.Events.Services;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.EnduranceEvents.Update
{
    public class UpdateEnduranceEvent : CreateEnduranceEvent
    {
        public class UpdateEnduranceEventHandler : Handler<UpdateEnduranceEvent, EnduranceEventForUpdateModel>
        {
            private readonly IEnduranceEventService enduranceEventService;
            private readonly ICommandsBase<EnduranceEvent> eventCommands;
            private readonly ICountryQueries countryQueries;

            public UpdateEnduranceEventHandler(
                IEnduranceEventService enduranceEventService,
                ICommandsBase<EnduranceEvent> eventCommands,
                ICountryQueries countryQueries)
            {
                this.enduranceEventService = enduranceEventService;
                this.eventCommands = eventCommands;
                this.countryQueries = countryQueries;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                UpdateEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = await this.eventCommands.Find(request.Id);
                if (enduranceEvent == null)
                {
                    throw new AppException("Endurance Event does not exit.");
                }

                enduranceEvent.Update(request);

                var competitions = request.Competitions.Select(x => new Competition(x.Id, x.Type, x.Name));
                competitions.ForEach(enduranceEvent.Add);

                if (enduranceEvent.Country?.IsoCode != request.CountryIsoCode)
                {
                    var country = await this.countryQueries.Find(request.CountryIsoCode);
                    enduranceEvent.Set(country);
                }

                enduranceEvent.ClearPersonnel();
                this.enduranceEventService
                    .PreparePersonnel(request)
                    .ForEach(enduranceEvent.Add);

                var result = await this.eventCommands.Save<EnduranceEventForUpdateModel>(
                    enduranceEvent,
                    cancellationToken);

                return result;
            }
        }
    }
}
