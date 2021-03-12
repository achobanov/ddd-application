using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;

namespace EnduranceJudge.Domain.Aggregates.Import.Events
{
    public class Event : BaseEvent<ImportEventException>, IAggregateRoot
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
