using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PhaseEntity : EntityModel, IPhaseState
    {
        public int LengthInKilometers { get; set; }

        public bool IsFinal { get; set; }

        [JsonIgnore]
        public IList<PhaseForCategoryEntity> PhasesForCategories { get; set; }

        public int CompetitionId { get; set; }

        [JsonIgnore]
        public Competition Competition { get; set; }
    }
}
