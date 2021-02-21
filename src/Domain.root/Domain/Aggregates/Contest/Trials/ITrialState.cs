using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Trials
{
    public interface ITrialState : IDomainModelState
    {
        int DurationInDays { get; }
    }
}
