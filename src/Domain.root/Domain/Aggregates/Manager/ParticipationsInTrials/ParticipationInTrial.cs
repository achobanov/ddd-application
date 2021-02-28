using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInTrials
{
    public class ParticipationInTrial : DomainModel<ParticipationInTrialException>
    {
        private const string EmptyPhasesCollection = "cannot start - Phases collection is empty";
        private const string NextPhaseIsNullMessage = "cannot start - there is no Next Phase.";
        private const string CurrentPhaseIsNullMessage = "cannot complete - no current phase.";

        private readonly TrialDto trial;

        internal ParticipationInTrial(TrialDto trial) : base(default)
        {
            this.Validate(() =>
            {
                trial.Phases.IsNotEmpty(EmptyPhasesCollection);
            });

            this.trial = trial;
            this.StartPhase();
        }

        public bool IsComplete
            => this.trial.Phases.Count == this.participationsInPhases.Count;

        public CompetitionType TrialType
            => this.trial.Type;

        public bool HasExceededSpeedRestriction
            => this.participationsInPhases.Any(participation => participation.HasExceededSpeedRestriction);

        public double? AverageSpeedInKpH
        {
            get
            {
                var completedPhases = this.participationsInPhases
                    .Where(x => x.IsComplete)
                    .ToList();

                if (!completedPhases.Any())
                {
                    return null;
                }

                var averageSpeedSum = completedPhases.Aggregate(0d, (sum, x) => sum + x.AverageSpeedInKpH!.Value);
                var phasesCount = this.participationsInPhases.Count;

                return averageSpeedSum / phasesCount;
            }
        }

        private readonly List<ParticipationInPhase> participationsInPhases = new();
        public ParticipationInPhase CurrentPhase
            => this.participationsInPhases.SingleOrDefault(participation => !participation.IsComplete);
        private void StartPhase()
            => this.Validate(() =>
            {
                var nextPhase = this.trial.Phases
                    .OrderBy(x => x.OrderBy)
                    .Skip(this.participationsInPhases.Count)
                    .FirstOrDefault()
                    .IsNotDefault(NextPhaseIsNullMessage);

                var restTime = this.CurrentPhase?.Phase.RestTimeInMinutes;
                var nextStartTime = this.CurrentPhase?.ReInspectionTime?.AddMinutes(restTime!.Value)
                                ?? this.CurrentPhase?.InspectionTime?.AddMinutes(restTime!.Value)
                                ?? this.trial.StartTime;

                var participation = new ParticipationInPhase(nextStartTime, nextPhase);

                this.Add(x => x.participationsInPhases, participation);
            });
        internal void CompleteSuccessful()
            => this.Validate(() =>
            {
                this.CurrentPhase
                    .IsNotDefault(CurrentPhaseIsNullMessage)
                    .CompleteSuccessful();

                this.StartPhase();
            });
        internal void CompleteUnsuccessful(string code)
            => this.Validate(() =>
            {
                this.CurrentPhase
                    .IsNotDefault(CurrentPhaseIsNullMessage)
                    .CompleteUnsuccessful(code);

                this.StartPhase();
            });
    }
}
