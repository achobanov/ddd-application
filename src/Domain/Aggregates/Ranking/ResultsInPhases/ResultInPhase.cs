using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Ranking.ResultsInPhases
{
    public class ResultInPhase : DomainBase<RankingResultInPhaseException>
    {
        internal ResultInPhase() 
        {
        }

        public bool IsRanked { get; private set; }
    }
}
