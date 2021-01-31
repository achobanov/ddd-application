using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Phases
{
    public interface IPhaseState : IEntityState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }

        IList<PhaseForCategory> PhasesForCategories { get; }
    }
}
