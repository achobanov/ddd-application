using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Domain.Interfaces;

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
