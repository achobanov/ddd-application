using EnduranceContestManager.Domain.Aggregates.Import.Participants;
using EnduranceContestManager.Domain.Core.Models;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Competitions
{
    public class Competition : DomainModel<ImportCompetitionException>
    {
        private readonly List<Participant> participants;

        public Competition(List<Participant> participants) : base(default)
        {
            this.participants = participants;
        }

        public IReadOnlyList<Participant> Participants => this.participants.AsReadOnly();
    }
}
