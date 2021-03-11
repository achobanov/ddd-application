using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Event.Phases
{
    public interface IPhaseState : IDomainModelState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }
    }
}
