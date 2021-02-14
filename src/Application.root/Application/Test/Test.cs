using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Models.Contests;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using EnduranceContestManager.Domain.Models.Phases;
using EnduranceContestManager.Domain.Models.Trials;
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

                var presidentGrandJury = new ContestWorker(0, "President GroundJury");
                var trial = new Trial(0, 100, 2);
                var trial2 = new Trial(0, 200, 3);

                contest.Add(trial).Add(trial2).Remove(x => x.DurationInDays == 3).Remove(trial);
                contest2.Add(trial).Add(trial2);
                ;
            }
        }
    }
}
