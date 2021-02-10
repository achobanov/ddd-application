using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Contests.Commands;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;
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
            private readonly IContestFactory factory;

            public TestHandler(IContestCommands contestCommands, IContestFactory factory)
            {
                this.contestCommands = contestCommands;
                this.factory = factory;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = this.factory.Create(new CreateContest
                {
                    Country = "New Country",
                    Name = "New Name",
                    ActiveVet = "New Active vet",
                    ForeignJudge = "New Foreign Judge",
                    PopulatedPlace = "New Populated place",
                    FeiTechDelegate = "new Fei Tech",
                    FeiVetDelegate = "New Fei Fet",
                    PresidentGroundJury = "New President jury",
                    PresidentVetCommission = "new President Vet",
                });

                var trial = new Trial(0, 50, 1);

                var firstPhase = new Phase(0, 20, 0);
                var finalPhase = new FinalPhase(0, 30, 0);

                var firstPhaseKids = new PhaseForCategory(0, 15, 15, Category.Kids);
                var finalPhaseKids = new PhaseForCategory(0, 20, 20, Category.Kids);

                firstPhase.AddPhaseForCategory(firstPhaseKids);
                finalPhase.AddPhaseForCategory(finalPhaseKids);

                trial.AddPhase(firstPhase).AddPhase(finalPhase);

                contest.AddTrial(trial);

                var contestData = contest.Map<ContestData>();

                //var id = await this.contestCommands.Save(contestData, cancellationToken);

                var kur = await this.contestCommands.Find<Contest>(1);
                ;
            }
        }
    }
}
