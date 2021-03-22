using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class EventEntity : EntityModel, IEventState, IMapFrom<Event>
    {
        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        [JsonIgnore]
        public IList<CompetitionEntity> Trials { get; set; }
    }
}
