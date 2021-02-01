using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Entities.Phases
{
    public class Phase : Entity, IPhaseState, IAggregateRoot
    {
        public Phase(
            int id,
            int lengthInKilometers,
            int trialId)
            : base(id)
        {
            this.TrialId = trialId;
            this.LengthInKilometers = lengthInKilometers;
        }

        public int LengthInKilometers { get; private set; }

        public IList<PhaseForCategory> PhasesForCategories { get; private set; } = new List<PhaseForCategory>();

        public int TrialId { get; private set; }

        public Trial Trial { get; private set; }

        public Phase AddPhaseForCategory(PhaseForCategory phaseForCategory)
        {
            if (this.PhasesForCategories.Any(x => x.Category == phaseForCategory.Category))
            {
                Thrower.Throw<PhaseException>($"Phase is already configured for {phaseForCategory.Category}");
            }

            this.PhasesForCategories.Add(phaseForCategory);
            return this;
        }
    }
}
