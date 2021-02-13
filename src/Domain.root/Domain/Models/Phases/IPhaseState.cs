using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Models.Phases
{
    public interface IPhaseState : IDomainModelState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }
    }
}
