using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Models.Contests;
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
            private readonly IContestCommands contestCommands;
            private readonly IContestFactory factory;

            public TestHandler(IContestCommands contestCommands, IContestFactory factory)
            {
                this.contestCommands = contestCommands;
                this.factory = factory;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = new Contest(
                    0,
                    "Name",
                    "Populated place",
                    "Country",
                    "President Ground Jury",
                    "Fei Tech Delegate",
                    "Fei Vet Delegate",
                    "President Vet Commission",
                    "Foreign Judge",
                    "Active Vet");

                var firstPhase = new Phase(0, 20, 0);

                var trial = new Trial(0, 100, 2)
                    .AddPhase(firstPhase);

                contest.AddTrial(trial);

                await this.contestCommands.Save(contest, cancellationToken);

                var result = await this.contestCommands.Find<Contest>(1);

                var trial2 = new Trial(0, 200, 3).AddPhase(firstPhase);



                ;
            }
        }
    }
}
