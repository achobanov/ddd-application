using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Trials
{
    public interface ITrialState : IDomainModelState
    {
        int LengthInKilometers { get;  }

        int DurationInDays { get; }
    }
}