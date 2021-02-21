using EnduranceContestManager.Domain.Aggregates.Import.Participants;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Trials
{
    public class Trial : DomainModel<ImportTrialException>
    {
        private readonly List<Participant> participants;

        public Trial(List<Participant> participants) : base(default)
        {
            this.participants = participants;
        }

        public IReadOnlyList<Participant> Participants => this.participants.AsReadOnly();
    }
}
