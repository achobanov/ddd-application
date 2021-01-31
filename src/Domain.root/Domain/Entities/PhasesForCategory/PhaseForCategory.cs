using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Interfaces;

namespace EnduranceContestManager.Domain.Entities.PhasesForCategory
{
    public class PhaseForCategory : Entity, IPhaseForCategoryState, IAggregateRoot
    {
        public PhaseForCategory(
            int id,
            int maxRecoveryTimeInMinutes,
            int restTimeInMinutes,
            int? minSpeedInKilometersPerHour = null,
            int? maxSpeedInKilometersPerHour = null)
            : base(id)
        {
            this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes;
            this.RestTimeInMinutes = restTimeInMinutes;
            this.MinSpeedInKilometersPerHour = minSpeedInKilometersPerHour;
            this.MaxSpeedInKilometersPerHour = maxSpeedInKilometersPerHour;
        }

        public int? MinSpeedInKilometersPerHour { get; private set; }

        public int? MaxSpeedInKilometersPerHour { get; private set; }

        public int MaxRecoveryTimeInMinutes { get; private set; }

        public int RestTimeInMinutes { get; private set; }
    }
}
