using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceJudge.Domain.Enums;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class PhaseForCategoryEntity : EntityModel, IPhaseForCategoryState, IMap<PhaseForCategory>
    {
        public int MaxRecoveryTimeInMinutes { get; set; }

        public int RestTimeInMinutes { get; set; }

        public Category Category { get; set; }

        public int PhaseId { get; set; }

        [JsonIgnore]
        public PhaseEntity Phase { get; set; }
    }
}
