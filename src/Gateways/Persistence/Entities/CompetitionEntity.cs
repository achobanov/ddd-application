using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CompetitionEntity : EntityModel<Competition>, ICompetitionState
    {
        public CompetitionType Type { get; set; }

        public int EventId { get; set; }

        [JsonIgnore]
        public EventEntity Event { get; set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; set; }
    }
}
