using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class PhaseForCategoryEntity : EntityModel<PhaseForCategory>, IPhaseForCategoryState
    {
        public PhaseForCategoryEntity()
        {
        }

        [JsonConstructor]
        public PhaseForCategoryEntity(
            int id,
            int maxRecoveryTimeInMinutes,
            int restTimeInMinutes,
            int? maxSpeedInKilometersPerHour,
            Category category,
            int phaseId)
            : base(id)
        {
            this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes;
            this.RestTimeInMinutes = restTimeInMinutes;
            this.MaxSpeedInKpH = maxSpeedInKilometersPerHour;
            this.Category = category;
            this.PhaseId = phaseId;
        }

        public int MaxRecoveryTimeInMinutes { get; internal set;}

        public int RestTimeInMinutes { get; internal set;}
        public int? MaxSpeedInKpH { get; internal set;}

        public Category Category { get; internal set; }

        public int PhaseId { get; internal set; }

        [JsonIgnore]
        public PhaseEntity Phase { get; internal set; }
    }
}
