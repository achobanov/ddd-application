using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases
{
    public class ParticipationInPhase : DomainModel<ParticipationInPhaseException>, IParticipationInPhaseState,
        IDependsOn<Participation>,
        IDependsOn<PhaseForCategory>
    {
        private const string NullPhaseOrPhaseForCategory = "Average speed cannot be determined without set Phase.";
        private const string NullTimeSpan = "Average speed cannot be determined without Phase Time or Loop Time.";

        public ParticipationInPhase(
            int id,
            DateTime startTime,
            DateTime? arrivalTime,
            DateTime? inspectionTime,
            DateTime? reInspectionTime)
            : base(id)
        {
            this.Except(() =>
            {
                this.StartTime = startTime.CheckDateHasPassed();
                this.ArrivalTime = arrivalTime.CheckDateHasPassed();
                this.InspectionTime = inspectionTime.CheckDateHasPassed();
                this.ReInspectionTime = reInspectionTime.CheckDateHasPassed();
            });
        }

        public DateTime StartTime { get; private set; }
        public DateTime? ArrivalTime { get; private set; }
        public DateTime? InspectionTime { get; private set; }
        public DateTime? ReInspectionTime { get; private set; }
        public Participation Participation { get; private set; }
        public PhaseForCategory PhaseForCategory { get; private set; }
        public ResultInPhase ResultInPhase { get; private set; }

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

        public double AverageSpeedInKpH
        {
            get
            {
                this.PhaseForCategory?.NotDefault(NullPhaseOrPhaseForCategory);

                var hasSpeedLimit = this.PhaseForCategory!.MinSpeedInKilometersPerHour.HasValue
                    || this.PhaseForCategory!.MaxSpeedInKilometersPerHour.HasValue;

                var timeSpan = hasSpeedLimit
                    ? this.LoopSpan
                    : this.PhaseSpan;

                timeSpan.NotDefault(NullTimeSpan);
                var phaseLengthInKm = this.PhaseForCategory.Phase.LengthInKilometers;
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

        public ParticipationInPhase CompleteSuccessful()
        {
            return this.Set(new ResultInPhase());
        }

        public ParticipationInPhase CompleteUnsuccessful(string code, bool isQualified = false)
        {
            return this.Set(new ResultInPhase(code, false, isQualified));
        }

        private ParticipationInPhase Set(ResultInPhase result)
        {
            this.Set(
                participationInPhase => participationInPhase.ResultInPhase,
                (participationInPhase, r) => participationInPhase.ResultInPhase = r,
                result);

            return this;
        }

        void IDependsOn<PhaseForCategory>.Set(PhaseForCategory domainModel)
            => this.Except(() =>
            {
                this.PhaseForCategory.CheckNotRelated();
                this.PhaseForCategory = domainModel;
            });

        void IDependsOn<PhaseForCategory>.Clear(PhaseForCategory domainModel)
        {
            this.PhaseForCategory = null;
        }

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
    }
}
