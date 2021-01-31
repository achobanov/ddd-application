using EnduranceContestManager.Domain.Interfaces;

namespace EnduranceContestManager.Domain.Entities.PhasesForCategory
{
    public interface IPhaseForCategoryState : IEntityState
    {
        int? MinSpeedInKilometersPerHour { get; }

        int? MaxSpeedInKilometersPerHour { get; }

        int MaxRecoveryTimeInMinutes { get; }

        int RestTimeInMinutes { get; }
    }
}
