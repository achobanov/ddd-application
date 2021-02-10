using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Entities.PhasesForCategory
{
    public interface IPhaseForCategoryState : IEntityState
    {
        int MaxRecoveryTimeInMinutes { get; }

        int RestTimeInMinutes { get; }

        int? MinSpeedInKilometersPerHour { get; }

        int? MaxSpeedInKilometersPerHour { get; }

        Phase Phase { get; }

        Category Category { get; }
    }
}
