using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInTrials;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class Participation : DomainModel<ManagerParticipationException>
    {
        private const string AlreadyStartedMessage = "has already started";

        private readonly IReadOnlyList<TrialDto> trials;
        private readonly List<ParticipationInTrial> participationsInTrials = new();

        public Participation(IReadOnlyList<TrialDto> trials) : base(default)
        {
            this.trials = trials;

            this.Validate(this.Start);
        }

        public bool HasExceededSpeedRestriction
            => this.participationsInTrials.All(participation => participation.HasExceededSpeedRestriction);

        public bool IsComplete
            => this.participationsInTrials.All(participation => participation.IsComplete);

        public IReadOnlyList<ParticipationInTrial> ParticipationsInTrials => this.participationsInTrials.AsReadOnly();

        private void Start()
            => this.Validate(() =>
            {
                this.participationsInTrials.IsEmpty(AlreadyStartedMessage);

                foreach (var participationInTrial in this.trials.Select(trial => new ParticipationInTrial(trial)))
                {
                    this.participationsInTrials.Add(participationInTrial);
                }
            });
        public void Arrive(DateTime time)
        {
            this.Update(participation => participation.CurrentPhase.Arrive(time));
        }
        public void Inspect(DateTime time)
        {
            this.Update(participation => participation.CurrentPhase.Inspect(time));
        }
        public void ReInspect(DateTime time)
        {
            this.Update(participation => participation.CurrentPhase.ReInspect(time));
        }
        public void CompleteSuccessful()
        {
            this.Update(participation => participation.CompleteSuccessful());
        }
        public void CompleteUnsuccessful(string code)
        {
            this.Update(participation => participation.CompleteUnsuccessful(code));
        }

        private void Update(Action<ParticipationInTrial> action)
        {
            foreach (var participation in this.participationsInTrials.Where(trial => !trial.IsComplete))
            {
                action(participation);
            }
        }
    }
}
