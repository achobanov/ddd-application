using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Phases
{
    public class Phase : Entity, IPhaseState, IAggregateRoot
    {
        public Phase(int id, int lengthInKilometers, bool isFinal, IList<PhaseForCategory> phasesForCategories)
            : base(id)
        {
            this.PhasesForCategories = phasesForCategories;
            this.LengthInKilometers = lengthInKilometers;
            this.IsFinal = isFinal;
        }

        public int LengthInKilometers { get; private set; }

        public bool IsFinal { get; private set; }

        public IList<PhaseForCategory> PhasesForCategories { get; private set; }
    }
}
