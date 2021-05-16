using EnduranceJudge.Domain.Aggregates.Import.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Import.EnduranceEvents
{
    public class EnduranceEvent : DomainBase<EnduranceEventException>, IAggregateRoot
    {
        private EnduranceEvent()
        {
        }

        public EnduranceEvent(List<Competition> competitions): base(default)
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
