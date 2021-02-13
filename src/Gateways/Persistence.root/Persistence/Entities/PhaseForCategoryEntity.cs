using EnduranceContestManager.Domain.Models.PhasesForCategory;
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
            int? minSpeedInKilometersPerHour,
            int? maxSpeedInKilometersPerHour,
            Category category,
            int phaseId)
            : base(id)
        {
            this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes;
            this.RestTimeInMinutes = restTimeInMinutes;
            this.MinSpeedInKilometersPerHour = minSpeedInKilometersPerHour;
            this.MaxSpeedInKilometersPerHour = maxSpeedInKilometersPerHour;
            this.Category = category;
            this.PhaseId = phaseId;
        }

        public int MaxRecoveryTimeInMinutes { get; internal set;}

        public int RestTimeInMinutes { get; internal set;}

        public int? MinSpeedInKilometersPerHour { get; internal set;}

        public int? MaxSpeedInKilometersPerHour { get; internal set;}

        public Category Category { get; internal set; }

        public int PhaseId { get; internal set; }

        [JsonIgnore]
        public PhaseEntity Phase { get; internal set; }
    }
}