using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory
{
    public interface IPhaseForCategoryState : IDomainModelState
    {
        int MaxRecoveryTimeInMinutes { get; }
        int RestTimeInMinutes { get; }
        Category Category { get; }
    }
}
