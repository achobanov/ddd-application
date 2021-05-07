using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.Events
{
    public class Event : DomainModel<ImportEventException>, IAggregateRoot
    {
        private Event()
        {
        }

        public Event(List<Competition> competitions)
        {
            this.competitions = competitions;
        }

        private List<Competition> competitions;
        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }

        public void Set(List<Competition> competitions)
        {
            this.competitions = competitions;
        }
    }
}
