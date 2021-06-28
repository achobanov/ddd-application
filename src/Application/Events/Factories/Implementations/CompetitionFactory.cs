using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using System.Linq;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class CompetitionFactory : ICompetitionFactory
    {
        private readonly IPhaseFactory phaseFactory;

        public CompetitionFactory(IPhaseFactory phaseFactory)
        {
            this.phaseFactory = phaseFactory;
        }

        public Competition Create(CompetitionDependantModel data)
        {
            var competition = new Competition(data);

            foreach (var phase in data.Phases.Select(this.phaseFactory.Create))
            {
                competition.Add(phase);
            }

            return competition;
        }
    }
}
