using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Entities.Trials;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Test
{
    public class Test : IRequest
    {
        public class TestHandler : Handler<Test>
        {
            private readonly IContestCommands contestCommands;

            public TestHandler(IContestCommands contestCommands)
            {
                this.contestCommands = contestCommands;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = await this.contestCommands.Find<Contest>(1);

                var trial = new Trial(0, 50, 1);

                var firstPhase = new Phase(0, 20, 0);
                var finalPhase = new FinalPhase(0, 30, 0);

                var firstPhaseKids = new PhaseForCategory(0, 15, 15);
            }
        }
    }
}
