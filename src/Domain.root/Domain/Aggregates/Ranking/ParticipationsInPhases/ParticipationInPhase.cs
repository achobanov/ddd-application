using EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases;
using EnduranceContestManager.Domain.Aggregates.Ranking.DTOs;
using EnduranceContestManager.Domain.Core.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ParticipationsInPhases
{
    public class ParticipationInPhase : DomainModel<RankingParticipationInPhaseException>
    {
        private ParticipationInPhase() : base(default)
        {
        }

        public DateTime ArrivalTime { get; }
        public DateTime InspectionTime { get; }
        public DateTime? ReInspectionTime { get; }
        public ResultInPhase Result { get; private set; }
        public PhaseForRanking Phase { get; private set; }

        public TimeSpan RecoverySpan
        {
            get
            {
                this.Validate(() =>
                {
                    this.ArrivalTime.IsNotDefault(nameof(this.ArrivalTime));
                    this.InspectionTime.IsNotDefault(nameof(this.ArrivalTime));
                });

                var inspectionTime = this.ReInspectionTime ?? this.InspectionTime;
                return this.ArrivalTime - inspectionTime;
            }
        }
    }
}
