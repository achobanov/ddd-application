using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using ImportEvent = EnduranceJudge.Domain.Aggregates.Import.Events.Event;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class EnduranceEventEntity : EntityModel, IEnduranceEventState,
        IMap<EnduranceEvent>,
        IMap<ImportEvent>
    {
        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        [JsonIgnore]
        public IList<CompetitionEntity> Competitions { get; set; }

        [JsonIgnore]
        public IList<PersonnelEntity> Personnel { get; set; }
    }
}
