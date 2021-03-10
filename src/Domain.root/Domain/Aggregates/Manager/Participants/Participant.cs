using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participants
{
    public class Participant : DomainModel<ManagerParticipantException>, IAggregateRoot
    {
        private Participant() : base(default)
        {
        }

        public int? MaxAverageSpeedInKpH { get; private set; }
        public IReadOnlyList<CompetitionDto> Competitions { get; private set; }

        public Participation Participation { get; private set; }
        public Participant Start()
        {
            this.Participation = new Participation(this.Competitions, this.MaxAverageSpeedInKpH);
            return this;
        }
    }
}
