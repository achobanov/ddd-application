using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Domain.Aggregates.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Event = EnduranceJudge.Domain.Aggregates.Event.Events.Event;

namespace EnduranceJudge.Application.Events.Commands
{
    public class SaveEvent : IRequest, IEventState
    {
        public string Name { get; set; }
        public string PopulatedPlace { get; set; }
        public string CountryIsoCode { get; set; }

        public class SaveEventHandler : Handler<SaveEvent>
        {
            private readonly ICommandsBase<Event> eventCommands;
            private readonly IEventFactory eventFactory;
            private readonly ICountryQueries countryQueries;

            public SaveEventHandler(
                ICommandsBase<Event> eventCommands,
                IEventFactory eventFactory,
                ICountryQueries countryQueries)
            {
                this.eventCommands = eventCommands;
                this.eventFactory = eventFactory;
                this.countryQueries = countryQueries;
            }

            protected override async Task Handle(SaveEvent request, CancellationToken cancellationToken)
            {
                var _event = this.eventFactory.Create(request);
                var country = await this.countryQueries.Find(request.CountryIsoCode);

                _event.Set(country);

                await this.eventCommands.Save(_event, cancellationToken);
            }
        }
    }
}
