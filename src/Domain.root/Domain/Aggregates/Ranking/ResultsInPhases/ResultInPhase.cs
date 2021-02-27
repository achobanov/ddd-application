using System;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases
{
    public class ResultInPhase : DomainModel<RankingResultInPhaseException>
    {
        internal ResultInPhase() : base(default)
        {
        }

        public bool IsRanked { get; private set; }

        public bool IsFinalPhase { get; private set; }

        public DateTime ArrivalTime { get; private set; }
    }
}
