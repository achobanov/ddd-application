using EnduranceContestManager.Domain.Aggregates.Contest.Phases;
using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class Participation : DomainModel<ManagerParticipationException>, IAggregateRoot
    {
        public Participation(int id) : base(id)
        {
        }

        public double AverageSpeedInKpH
        {
            get
            {
                var sum = this.participationsInPhases
                    .Where(x => x.IsComplete)
                    .Aggregate(0d, (participationSum, x) => participationSum + x.AverageSpeedInKpH);

                var count = this.participationsInPhases.Count;

                return sum / count;
            }
        }

        private readonly List<ParticipationInPhase> participationsInPhases = new();
        public IReadOnlyList<ParticipationInPhase> ParticipationsInPhases => this.participationsInPhases.AsReadOnly();
        public ParticipationInPhase Current { get; private set; }
        public ParticipationInPhase StartPhase(IPhaseState phase)
        {
            this.Current = new ParticipationInPhase(DateTime.Now)
                .Start(phase);

            this.Add(x => x.participationsInPhases, this.Current);

            return this.Current;
        }

        public Participant Participant { get; private set; }
        public Participation Set(Participant participant)
        {
            this.Set(
                participation => participation.Participant,
                (participation, p) => participation.Participant = p,
                participant);

            return this;
        }
    }
}
