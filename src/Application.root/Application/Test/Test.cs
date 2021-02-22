using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Aggregates.Contest.Contests;
using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using EnduranceContestManager.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Test
{
    public class Test : IRequest, IMapTo<Contest>
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            public TestHandler()
            {
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = new Contest(0, "Name", "Populated place", "Country");
                var contest2 = new Contest(1, "Name2", "Populated place2", "Country");

                var presidentGrandJury = new Personnel(0, "President GroundJury");
                var trial = new Trial(0, CompetitionType.National);
                var trial2 = new Trial(0, CompetitionType.International);

                contest.SetPresidentGroundJury(presidentGrandJury);

                contest.Add(trial).Add(trial2).Remove(x => x.Type == CompetitionType.National).Remove(trial);
                contest2.Add(trial).Add(trial2);
                ;
            }
        }
    }
}
