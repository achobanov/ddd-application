using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases
{
    public class ParticipationInPhase : DomainModel<ParticipationInPhaseException>, IParticipationInPhaseState,
        IDependsOn<Participation>
    {
        private const string NullPhaseOrPhaseForCategory = "Average speed cannot be determined without set Phase.";
        private const string NullTimeSpan = "Average speed cannot be determined without Phase Time or Loop Time.";

        internal ParticipationInPhase(DateTime startTime) : base(default)
            => this.Except(() =>
            {
                this.StartTime = startTime.CheckDateHasPassed();
            });

        public DateTime StartTime { get; private set; }
        public DateTime? ArrivalTime { get; private set; }
        public DateTime? InspectionTime { get; private set; }
        public DateTime? ReInspectionTime { get; private set; }

        public TimeSpan? RecoverySpan
        {
            get
            {
                var inspectionTime = this.ReInspectionTime ?? this.InspectionTime;

                return this.ArrivalTime - inspectionTime;
            }
        }

        public TimeSpan? LoopSpan
        {
            get
            {
                return this.ArrivalTime - this.StartTime;
            }
        }

        public TimeSpan? PhaseSpan
        {
            get
            {
                return this.ArrivalTime - this.InspectionTime;
            }
        }

        // TODO: Split into averate speed with/without RestTime.
        public double AverageSpeedInKpH
        {
            get
            {
                this.PhaseForCategory?.NotDefault(NullPhaseOrPhaseForCategory);

                var hasSpeedLimit = this.PhaseForCategory!.MaxSpeedInKilometersPerHour.HasValue;

                var timeSpan = hasSpeedLimit
                    ? this.LoopSpan
                    : this.PhaseSpan;

                timeSpan.NotDefault(NullTimeSpan);

                var phaseLengthInKm = this.Phase.LengthInKilometers;
                var totalHours = timeSpan!.Value.TotalHours;

                return  phaseLengthInKm / totalHours;
            }
        }

        public bool IsComplete
        {
            get
            {
                return this.ResultInPhase != null;
            }
        }

        public IPhaseState Phase { get; private set; }
        public IPhaseForCategoryState PhaseForCategory { get; private set; }
        public ParticipationInPhase Start(IPhaseState phase)
        {
            this.Phase = phase.IsRequired(nameof(phase));
            return this;
        }
        public ParticipationInPhase InCategory(IPhaseForCategoryState phaseForCategoryState)
        {
            this.PhaseForCategory = phaseForCategoryState.IsRequired(nameof(phaseForCategoryState));
            return this;
        }
        public ParticipationInPhase Arrive(DateTime time)
        {
            this.ArrivalTime = time.IsRequired(nameof(time));
            return this;
        }
        public ParticipationInPhase Inspect(DateTime time)
        {
            this.InspectionTime = time.IsRequired(nameof(time));
            return this;
        }
        public ParticipationInPhase ReInspect(DateTime time)
        {
            // TODO: ReInspection does not reset the RestTime for the Horse. Check if needed
            this.ReInspectionTime = time.IsRequired(nameof(time));
            return this;
        }

        public ResultInPhase ResultInPhase { get; private set; }
        public ParticipationInPhase CompleteSuccessful()
        {
            var successfulResult = new ResultInPhase();
            return this.Set(successfulResult);
            // TODO: Calculate Next Phase start time from this.ReInnspectionTme ??  this.InspectionTime and complete.
        }
        public ParticipationInPhase CompleteUnsuccessful(string code, bool isQualified = false)
        {
            var unsuccessfulResult = new ResultInPhase(code, isRanked: false, isQualified);
            return this.Set(unsuccessfulResult);
        }

        public Participation Participation { get; private set; }
        void IDependsOn<Participation>.Set(Participation domainModel)
            => this.Except(() =>
            {
                this.Participation.CheckNotRelated();
                this.Participation = domainModel;
            });

        void IDependsOn<Participation>.Clear(Participation domainModel)
        {
            this.Participation = null;
        }

        private ParticipationInPhase Set(ResultInPhase result)
        {
            this.Set(
                participationInPhase => participationInPhase.ResultInPhase,
                (participationInPhase, r) => participationInPhase.ResultInPhase = r,
                result);

            return this;
        }
    }
}
