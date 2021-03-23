using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Interfaces.Events;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Test
{
    public class Test : IRequest, IMapTo<Event>
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            private readonly IEventCommands commands;

            public TestHandler(IEventCommands commands)
            {
                this.commands = commands;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                // await this.Create(cancellationToken);
                await this.Modify(cancellationToken);
            }

            private async Task Create(CancellationToken cancellationToken)
            {
                var event_ = new Event(0, "Name", "place");
                var competition1 = new Competition(1, CompetitionType.International);
                var competition2 = new Competition(2, CompetitionType.National);
                var competition3 = new Competition(3, CompetitionType.National);

                event_.Add(competition1);
                event_.Add(competition2);
                event_.Add(competition3);

                await this.commands.Save(event_, cancellationToken);
            }

            private async Task Modify(CancellationToken cancellationToken)
            {
                var event_ = await this.commands.Find<Event>(1);
                event_.Remove(x => x.Id == 1);

                await this.commands.Save(event_, cancellationToken);

                var competition2 = new Competition(0, CompetitionType.National);
                event_.Add(competition2);

                await this.commands.Save(event_, cancellationToken);
            }
        }
    }
}
