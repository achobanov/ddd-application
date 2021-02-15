using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Phases
{
    public interface IPhaseState : IDomainModelState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }
    }
}
