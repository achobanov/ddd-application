using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participant
{
    public class Participant : DomainModel<ManagerParticipantException>, IAggregateRoot
    {
        private readonly List<TrialDto> trials = new();

        private Participant() : base(default)
        {
        }

        public Participation Participation { get; private set; }

        public IReadOnlyList<TrialDto> Trials => this.trials.AsReadOnly();

        public Participant Start()
        {
            this.Participation = new Participation(this.Trials);
            return this;
        }
    }
}
