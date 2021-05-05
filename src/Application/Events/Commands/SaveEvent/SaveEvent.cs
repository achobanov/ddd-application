using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Event = EnduranceJudge.Domain.Aggregates.Event.Events.Event;

namespace EnduranceJudge.Application.Events.Commands.SaveEvent
{
    public class SaveEvent : IRequest, IEventState
    {
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }
        public string PresidentGroundJuryName { get; set; }
        public class SaveEventHandler : Handler<SaveEvent>
        {
            private readonly ICommandsBase<Event> eventCommands;
            private readonly IEventFactory eventFactory;
            private readonly IPersonnelFactory personnelFactory;
            private readonly ICountryQueries countryQueries;

            public SaveEventHandler(
                ICommandsBase<Event> eventCommands,
                IEventFactory eventFactory,
                IPersonnelFactory personnelFactory,
                ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.eventFactory = eventFactory;
                this.personnelFactory = personnelFactory;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(SaveEvent request, CancellationToken cancellationToken)
            {
                var _event = this.eventFactory.Create(request);
                var country = await this.countryQueries.Find(request.CountryIsoCode);

                _event.Set(country);

                var presidentGroundJury = this.personnelFactory.Create(
                    request.PresidentGroundJuryName,
                    PersonnelRole.PresidentGroundJury);

                _event.Add(presidentGroundJury);

                await this.eventCommands.Save(_event, cancellationToken);
            }
        }
    }
}
