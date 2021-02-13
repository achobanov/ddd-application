using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Enums;
using MediatR;
using System.Linq;
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

                var trial = new Trial(0, 100, 2);
                // var trial2 = new Trial(0, 200, 2);
                contest.AddTrial(trial);
                // contest.AddTrial(trial2);

                await this.contestCommands.Save(contest, cancellationToken);
                // var contest2 = await this.contestCommands.Find<Contest>(1);
                //
                // for (var i = 1; i <= 2; i++)
                // {
                //     var newTrial = new Trial(0, 60 * i, 3);
                //     contest2.AddTrial(newTrial);
                // }
                //
                // await this.contestCommands.Save(contest2, cancellationToken);

                // var firstPhase = new Phase(0, 20, 0);
                // var finalPhase = new FinalPhase(0, 30, 0);
                //
                // var firstPhaseKids = new PhaseForCategory(0, 15, 15, Category.Kids);
                // var finalPhaseKids = new PhaseForCategory(0, 20, 20, Category.Kids);
                //
                // firstPhase.AddPhaseForCategory(firstPhaseKids);
                // finalPhase.AddPhaseForCategory(finalPhaseKids);
                //
                // var trial = new Trial(0, 100, 2)
                //     .AddPhase(firstPhase)
                //     .AddPhase(finalPhase);
                //
                // var contest = await this.contestCommands.Find<Contest>(1);
                // contest.Trials.First().AddPhase(finalPhase);
                // contest.AddTrial(trial);
                //
                //
                // await this.contestCommands.Save(contest, cancellationToken);
                // await this.contestCommands.Save(contest, cancellationToken);

                var result = await this.contestCommands.Find<Contest>(1);
                ;
            }
        }
    }
}
