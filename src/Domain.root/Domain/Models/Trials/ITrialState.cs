using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Models.Trials
{
    public interface ITrialState : IDomainModelState
    {
        int LengthInKilometers { get;  }

        int DurationInDays { get; }
    }
}
