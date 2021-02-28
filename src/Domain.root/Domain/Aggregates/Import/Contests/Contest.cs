using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Import.Trials;
using EnduranceContestManager.Domain.Core.Entities;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Contests
{
    public class Contest : BaseContest<ImportContestException>, IAggregateRoot
    {
        private readonly List<Trial> trials;

        public Contest(string name, string populatedPlace, List<Trial> trials)
            : base(default, name, populatedPlace)
        {
            this.trials = trials;
        }

        public IReadOnlyList<Trial> Trials => this.trials.AsReadOnly();
    }
}
