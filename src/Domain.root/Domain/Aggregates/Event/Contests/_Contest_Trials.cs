using EnduranceContestManager.Domain.Aggregates.Event.Trials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
{
    public partial class Contest
    {
        private readonly List<Trial> trials = new();

        [NotMapped]
        public IReadOnlyList<Trial> Trials => this.trials.AsReadOnly();

        public Contest Add(Trial trial)
        {
            this.Add(x => x.trials, trial);
            return this;
        }

        public Contest Remove(Func<Trial, bool> filter)
        {
            var trial = this.trials.FirstOrDefault(filter);
            return this.Remove(trial);
        }

        public Contest Remove(Trial trial)
        {
            this.Remove(x => x.trials, trial);
            return this;
        }
    }
}
