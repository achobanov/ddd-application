using EnduranceContestManager.Domain.Models.Trials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public List<Trial> Trials { get; private set; } = new();

        public Contest Add(Trial trial)
        {
            this.Add(x => x.Trials, trial);

            return this;
        }

        public Contest Remove(Func<Trial, bool> filter)
        {
            var trial = this.Trials.FirstOrDefault(filter);
            return this.Remove(trial);
        }

        public Contest Remove(Trial trial)
        {
            this.Remove(x => x.Trials, trial);

            return this;
        }
    }
}
