using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Entities.Trials
{
    public interface ITrialState : IEntityState
    {
        int LengthInKilometers { get;  }

        int DurationInDays { get; }
    }
}
