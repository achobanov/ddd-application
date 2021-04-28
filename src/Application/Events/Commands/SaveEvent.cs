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

        public class SaveEventHandler : Handler<SaveEvent>
        {
            private readonly ICommandsBase<Event> eventCommands;
            private readonly IEventFactory eventFactory;

            public SaveEventHandler(ICommandsBase<Event> eventCommands, IEventFactory eventFactory)
            {
                this.eventCommands = eventCommands;
                this.eventFactory = eventFactory;
            }

            protected override async Task Handle(SaveEvent request, CancellationToken cancellationToken)
            {
                var _event = this.eventFactory.Create(request);
                await this.eventCommands.Save(_event, cancellationToken);
            }
        }
    }
}
