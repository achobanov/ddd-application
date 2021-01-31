using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Trials
{
    public interface ITrialState : IEntityState
    {
        int LengthInKilometers { get;  }

        int DurationInDays { get; }

        IList<Phase> Phases { get; }
    }
}
