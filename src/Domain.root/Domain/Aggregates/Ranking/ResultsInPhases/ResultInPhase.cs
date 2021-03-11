using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases
{
    public class ResultInPhase : DomainModel<RankingResultInPhaseException>
    {
        internal ResultInPhase() : base(default)
        {
        }

        public bool IsRanked { get; private set; }
    }
}
