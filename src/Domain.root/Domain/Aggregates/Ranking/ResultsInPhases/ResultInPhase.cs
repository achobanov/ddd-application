using EnduranceContestManager.Domain.Core.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases
{
    public class ResultInPhase : DomainModel<RankingResultInPhaseException>
    {
        public ResultInPhase(bool isRanked, bool isFinalPhase, DateTime arrivalTime) : base(default)
        {
            this.IsRanked = isRanked;
            this.IsFinalPhase = isFinalPhase;
            this.ArrivalTime = arrivalTime.IsRequired(nameof(arrivalTime));
        }

        public bool IsRanked { get; private set; }

        public bool IsFinalPhase { get; private set; }

        public DateTime ArrivalTime { get; private set; }
    }
}
