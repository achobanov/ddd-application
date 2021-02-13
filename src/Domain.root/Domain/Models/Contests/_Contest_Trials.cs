using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Trials;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public IList<Trial> Trials { get; private set; } = new List<Trial>();

        public Contest Add(Trial trial)
        {
            this.Trials
                .CheckExistingAndAdd<Trial, ContestException>(trial)
                .SetContest(this);

            return this;
        }

        public Contest Remove(Func<Trial, bool> filter)
        {
            var trial = this.Trials.FirstOrDefault(filter);
            this.Trials
                .CheckNotExistingAndRemove<Trial, ContestException>(trial)
                .ClearContest();

            return this;
        }
    }
}
