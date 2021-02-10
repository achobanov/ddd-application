using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Entities.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Phases
{
    public interface IPhaseState : IEntityState
    {
        int LengthInKilometers { get; }

        IList<PhaseForCategory> PhasesForCategories { get; }

        int TrialId { get; }

        Trial Trial { get; }
    }
}
