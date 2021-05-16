using EnduranceJudge.Domain.Aggregates.Event.Competitions;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class CompetitionFactory : ICompetitionFactory
    {
        public Competition Create(ICompetitionState state)
        {
            var competition = new Competition(state.Type);
            return competition;
        }
    }
}
