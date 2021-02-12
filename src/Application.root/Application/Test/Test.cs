using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
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
                // var firstPhase = new Phase(0, 20, 0);
                // var finalPhase = new FinalPhase(0, 30, 0);
                //
                // var firstPhaseKids = new PhaseForCategory(0, 15, 15, Category.Kids);
                // var finalPhaseKids = new PhaseForCategory(0, 20, 20, Category.Kids);
                //
                // firstPhase.AddPhaseForCategory(firstPhaseKids);
                // finalPhase.AddPhaseForCategory(finalPhaseKids);
                //
                // trial.AddPhase(firstPhase).AddPhase(finalPhase);

                var contest = await this.contestCommands.Find<Contest>(1);

                var id = await this.contestCommands.Save(contest, cancellationToken);
                var result = await this.contestCommands.Find<Contest>(1);
                ;
            }
        }
    }
}
