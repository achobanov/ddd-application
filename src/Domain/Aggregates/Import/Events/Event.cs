using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.Events
{
    public class Event : BaseEvent<ImportEventException>, IAggregateRoot
    {
        public Event(string name, string populatedPlace, List<Competition> competitions)
            : base(default, name, populatedPlace)
        {
            this.competitions = competitions;
        }

        private List<Competition> competitions;
        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }
    }
}
