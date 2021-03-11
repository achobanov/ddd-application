using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Aggregates.Event.Events;
using EnduranceContestManager.Domain.Aggregates.Event.Competitions;
using EnduranceContestManager.Domain.Aggregates.Manager.Participants;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Test
{
    public class Test : IRequest, IMapTo<Event>
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            public TestHandler()
            {
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = new Event(0, "Name", "place");

                var competition1 = new Competition(0, CompetitionType.International);
                var competition2 = new Competition(1, CompetitionType.National);
                var competition3 = new Competition(1, CompetitionType.National);

                contest.Add(competition1);
                contest.Add(competition2);

                contest.Remove(competition1);
                contest.Add(competition3);
            }
        }
    }
}
