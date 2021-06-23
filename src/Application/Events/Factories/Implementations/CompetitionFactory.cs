using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class CompetitionFactory : ICompetitionFactory
    {
        public Competition Create(CompetitionDependantModel data)
        {
            var competition = new Competition(data.Id, data.Type, data.Name);
            return competition;
        }
    }
}
