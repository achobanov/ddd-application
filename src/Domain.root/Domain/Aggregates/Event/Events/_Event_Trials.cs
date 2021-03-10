using EnduranceContestManager.Domain.Aggregates.Event.Trials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        private readonly List<Trial> trials = new();

        [NotMapped]
        public IReadOnlyList<Trial> Trials => this.trials.AsReadOnly();

        public Event Add(Trial trial)
        {
            this.Add(x => x.trials, trial);
            return this;
        }

        public Event Remove(Func<Trial, bool> filter)
        {
            var trial = this.trials.FirstOrDefault(filter);
            return this.Remove(trial);
        }

        public Event Remove(Trial trial)
        {
            this.Remove(x => x.trials, trial);
            return this;
        }
    }
}
