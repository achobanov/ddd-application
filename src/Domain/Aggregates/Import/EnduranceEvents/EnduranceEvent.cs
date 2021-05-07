using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.EnduranceEvents
{
    public class EnduranceEvent : DomainModel<EnduranceEventException>, IAggregateRoot
    {
        private EnduranceEvent()
        {
        }

        public EnduranceEvent(List<Competition> competitions)
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
