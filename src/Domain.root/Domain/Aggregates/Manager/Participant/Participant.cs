using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.DTOs;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participant
{
    public class Participant : DomainModel<ManagerParticipantException>, IAggregateRoot
    {
        public Participant(List<TrialDto> trials) : base(default)
        {
            this.Trials = trials;
        }

        public Participation Participation { get; private set; }

        public List<TrialDto> Trials { get; private set; }

        public Participant Start()
        {
            this.Participation = new Participation(this.Trials);
            return this;
        }
    }
}
