using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory
{
    public interface IPhaseForCategoryState : IDomainModelState
    {
        int MaxRecoveryTimeInMinutes { get; }

        int RestTimeInMinutes { get; }

        int? MinSpeedInKilometersPerHour { get; }

        int? MaxSpeedInKilometersPerHour { get; }

        Category Category { get; }
    }
}
