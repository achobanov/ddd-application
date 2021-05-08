using EnduranceJudge.Domain.Aggregates.Import.Participants;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Core.Validation;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.Competitions
{
    public class Competition : DomainModel<ImportCompetitionException>
    {
        private Competition()
        {
        }

        public Competition(List<Participant> participants)
            => this.Validate(() =>
            {
                this.participants = participants.IsRequired(nameof(participants));
            });

        private List<Participant> participants;
        public IReadOnlyList<Participant> Participants
        {
            get => this.participants.AsReadOnly();
            private set => this.participants = value.ToList();
        }
        public void Set(List<Participant> participants)
        {
            this.participants = participants;
        }
    }
}
