using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Application.Events.Queries.GetEvent;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.EnduranceEvents
{
    public class SaveEnduranceEvent : IRequest<EnduranceEventForUpdateModel>, IEnduranceEventState
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }
        public IEnumerable<PersonnelDependantModel> Personnel { get; set; }
        public IEnumerable<CompetitionDependantModel> Competitions { get; set;}

        public class SaveEnduranceEventHandler : Handler<SaveEnduranceEvent, EnduranceEventForUpdateModel>
        {
            private readonly IEnduranceEventFactory enduranceEventFactory;
            private readonly ICommandsBase<EnduranceEvent> eventCommands;
            private readonly ICountryQueries countryQueries;

            public SaveEnduranceEventHandler(
                IEnduranceEventFactory enduranceEventFactory,
                ICommandsBase<EnduranceEvent> eventCommands,
                ICountryQueries countryQueries)
            {
                this.enduranceEventFactory = enduranceEventFactory;
                this.eventCommands = eventCommands;
                this.countryQueries = countryQueries;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                SaveEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = this.enduranceEventFactory.Create(request);

                var country = await this.countryQueries.Find(request.CountryIsoCode);
                enduranceEvent.Set(country);

                var result = await this.eventCommands.Save<EnduranceEventForUpdateModel>(
                    enduranceEvent,
                    cancellationToken);

                return result; ;
            }
        }
    }
}
