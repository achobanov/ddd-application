using EnduranceContestManager.Domain.Interfaces;

namespace EnduranceContestManager.Domain.Entities.Trials
{
    public interface ITrialState : IEntityState
    {
        int LengthInKilometers { get;  }

        int DurationInDays { get; }
    }
}
