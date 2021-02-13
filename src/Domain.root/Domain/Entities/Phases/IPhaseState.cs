using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Entities.Phases
{
    public interface IPhaseState : IEntityState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }
    }
}
