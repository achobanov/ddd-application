using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Import.Trials;
using EnduranceContestManager.Domain.Core.Entities;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Contests
{
    public class Event : BaseEvent<ImportContestException>, IAggregateRoot
    {
        private readonly List<Trial> trials;

        public Event(string name, string populatedPlace, List<Trial> trials)
            : base(default, name, populatedPlace)
        {
            this.trials = trials;
        }

        public IReadOnlyList<Trial> Trials => this.trials.AsReadOnly();
    }
}
