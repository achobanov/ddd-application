using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Aggregates.Import.Participants;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Import.Factories.Implementations
{
    public class CompetitionFactory : ICompetitionFactory
    {
        public Competition  Create(List<Participant> participants)
        {
            var competition = new Competition(participants);
            return competition;
        }
    }
}
