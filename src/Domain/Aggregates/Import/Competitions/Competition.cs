using EnduranceJudge.Domain.Aggregates.Import.Participants;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.Competitions
{
    public class Competition : DomainModel<ImportCompetitionException>
    {
        public Competition(List<Participant> participants) : base(default)
        {
            this.participants = participants;
        }

        private List<Participant> participants;
        public IReadOnlyList<Participant> Participants
        {
            get => this.participants.AsReadOnly();
            private set => this.participants = value.ToList();
        }
    }
}
