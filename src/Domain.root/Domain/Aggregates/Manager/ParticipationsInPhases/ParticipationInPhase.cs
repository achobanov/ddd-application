using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInTrials;
using EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases
{
    public class ParticipationInPhase : DomainModel<ParticipationInPhaseException>, IParticipationInPhaseState,
        IDependsOn<ParticipationInTrial>
    {
        private static readonly string ArrivalTimeIsNullMessage = $"cannot complete: ArrivalTime cannot be null.";
        private static readonly string InspectionTimeIsNullMessage = $"cannot complete: InspectionTime cannot be null";

        internal ParticipationInPhase(DateTime startTime, PhaseDto phase) : base(default)
            => this.Validate(() =>
            {
                this.StartTime = startTime
                    .IsRequired(nameof(startTime))
                    .HasDatePassed();

                this.Phase = phase.IsRequired(nameof(phase));
            });

        public DateTime StartTime { get; private set; }
        public DateTime? ArrivalTime { get; private set; }
        public DateTime? InspectionTime { get; private set; }
        public DateTime? ReInspectionTime { get; private set; }

        public PhaseDto Phase { get; private set; }

        public TimeSpan? RecoverySpan
        {
            get
            {
                var inspectionTime = this.ReInspectionTime ?? this.InspectionTime;
                return this.ArrivalTime - inspectionTime;
            }
        }

        public TimeSpan? LoopSpan
            => this.ArrivalTime - this.StartTime;

        public TimeSpan? PhaseSpan
            => this.ArrivalTime - this.InspectionTime;

        // TODO: Split into average speed with/without RestTime.
        public double? AverageSpeedInKpH
        {
            get
            {
                if (this.Phase == null || this.LoopSpan == null && this.PhaseSpan == null)
                {
                    return null;
                }

                var hasSpeedLimit = this.Phase!.MaxSpeedInKpH.HasValue;

                var timeSpan = hasSpeedLimit
                    ? this.LoopSpan
                    : this.PhaseSpan;

                var phaseLengthInKm = this.Phase.LengthInKilometers;
                var totalHours = timeSpan!.Value.TotalHours;

                return  phaseLengthInKm / totalHours;
            }
        }

        public bool HasExceededSpeedRestriction
            => this.AverageSpeedInKpH > this.Phase?.MaxSpeedInKpH;

        public bool IsComplete
            => this.ResultInPhase != null;

        internal void Arrive(DateTime time)
        {
            this.ArrivalTime = time.IsRequired(nameof(time));
        }

        internal void Inspect(DateTime time)
        {
            this.InspectionTime = time.IsRequired(nameof(time));
        }

        internal void ReInspect(DateTime time)
        {
            this.ReInspectionTime = time.IsRequired(nameof(time));
        }

        public ResultInPhase ResultInPhase { get; private set; }

        internal void CompleteSuccessful()
        {
            var successfulResult = new ResultInPhase();
            this.Complete(successfulResult);
        }

        internal void CompleteUnsuccessful(string code)
        {
            var unsuccessfulResult = new ResultInPhase(code, isRanked: false);
            this.Complete(unsuccessfulResult);
        }

        public ParticipationInTrial ParticipationInTrial { get; private set; }
        void IDependsOn<ParticipationInTrial>.Set(ParticipationInTrial domainModel)
            => this.Validate(() =>
            {
                this.ParticipationInTrial.IsNotRelated();
                this.ParticipationInTrial = domainModel;
            });

        void IDependsOn<ParticipationInTrial>.Clear(ParticipationInTrial domainModel)
        {
            this.ParticipationInTrial = null;
        }

        private void Complete(ResultInPhase result)
        {
            this.Validate(() =>
            {
                this.ArrivalTime.IsNotDefault(ArrivalTimeIsNullMessage);
                this.InspectionTime.IsNotDefault(InspectionTimeIsNullMessage);
            });

            this.Set(
                participationInPhase => participationInPhase.ResultInPhase,
                (participationInPhase, r) => participationInPhase.ResultInPhase = r,
                result);
        }
    }
}
