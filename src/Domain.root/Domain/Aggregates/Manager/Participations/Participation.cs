using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Aggregates.Manager.Results;
using EnduranceContestManager.Domain.Core.Entities;
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
        public List<ParticipationInPhase> ParticipationInPhases { get; private set; } = new();

        public Result Result { get; } = new();

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
