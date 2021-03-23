using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        private List<Competition> competitions = new();

        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }

        public Event Add(Competition competition)
        {
            this.Add(x => x.competitions, competition);
            return this;
        }

        public Event Remove(Func<Competition, bool> filter)
        {
            var competition = this.competitions.FirstOrDefault(filter);
            return this.Remove(competition);
        }

        public Event Remove(Competition competition)
        {
            this.Remove(x => x.competitions, competition);
            return this;
        }
    }
}
