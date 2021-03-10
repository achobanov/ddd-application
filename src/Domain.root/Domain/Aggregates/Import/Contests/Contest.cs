using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Import.Competitions;
using EnduranceContestManager.Domain.Core.Entities;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Contests
{
    public class Event : BaseEvent<ImportContestException>, IAggregateRoot
    {
        private readonly List<Competition> competitions;

        public Event(string name, string populatedPlace, List<Competition> competitions)
            : base(default, name, populatedPlace)
        {
            this.competitions = competitions;
        }

        public IReadOnlyList<Competition> Competitions => this.competitions.AsReadOnly();
    }
}
