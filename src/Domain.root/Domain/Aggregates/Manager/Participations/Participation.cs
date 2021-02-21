using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class Participation : DomainModel<ParticipationException>, IParticipationState, IAggregateRoot
    {
        public Participation(int id)
            : base(id)
        {
        }

        public float AverageSpeedInKpH { get; }
        public Participant Participant { get; private set; }
        public ParticipationInPhase Current { get; private set; }
        public List<ParticipationInPhase> ParticipationInPhases { get; private set; } = new();

        public ParticipationInPhase StartPhase(IPhaseState phase)
        {
            this.Current = new ParticipationInPhase(DateTime.Now)
                .Start(phase);

            this.Add(x => x.ParticipationInPhases, this.Current);

            return this.Current;
        }

        public Participation Set(Participant participant)
        {
            this.Set(
                participation => participation.Participant,
                (participation, p) => participation.Participant = p,
                participant);

            return this;
        }

        public Participation Add(ParticipationInPhase participationInPhase)
        {
            this.Add(
                participation => participation.ParticipationInPhases,
                participationInPhase);

            return this;
        }
    }
}
