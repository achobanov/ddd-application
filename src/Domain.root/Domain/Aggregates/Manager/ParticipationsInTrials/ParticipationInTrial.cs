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
        private readonly int? maxAverageSpeedInKpH;

        internal ParticipationInTrial(TrialDto trial, int? maxAverageSpeedInKpH) : base(default)
        {
            this.Validate(() =>
            {
                trial.Phases.IsNotEmpty(EmptyPhasesCollection);
            });

            this.maxAverageSpeedInKpH = maxAverageSpeedInKpH;
            this.trial = trial;

            this.StartPhase();
        }


        public bool IsComplete
            => this.trial.Phases.Count == this.participationsInPhases.Count;

        public CompetitionType TrialType
            => this.trial.Type;

        public bool HasExceededSpeedRestriction
            => this.AverageSpeedInKpH > this.maxAverageSpeedInKpH;

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

                var averageSpeedInPhases = this.TrialType == CompetitionType.International
                    ? completedPhases.Select(x => x.AverageSpeedForPhaseInKpH!.Value)
                    : completedPhases.Select(x => x.AverageSpeedForLoopInKpH!.Value);

                var averageSpeedSum = averageSpeedInPhases.Aggregate(0d, (sum, average) => sum + average);
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

                var participation = new ParticipationInPhase(nextPhase, nextStartTime);
                this.participationsInPhases.Add(participation);
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
