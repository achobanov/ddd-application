using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.PhasesForCategory;
using EnduranceContestManager.Domain.Models.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Models.Phases
{
    public class Phase : DomainModel, IPhaseState, IAggregateRoot
    {
        public Phase(int id, int lengthInKilometers, int trialId)
            : base(id)
        {
            this.TrialId = trialId;
            this.LengthInKilometers = lengthInKilometers;
        }

        public int LengthInKilometers { get; private set; }

        public bool IsFinal { get; private set; }

        public IList<PhaseForCategory> PhasesForCategories { get; private set; } = new List<PhaseForCategory>();

        public int TrialId { get; private set; }

        public Trial Trial { get; private set; }

        public Phase SetTrial(Trial trial)
        {
            this.Trial.CheckNotNullAndSet<Trial, PhaseException>(trial);
            return this;
        }

        public Phase AddPhaseForCategory(PhaseForCategory phaseForCategory)
        {
            this.PhasesForCategories.CheckExistingAndAdd<PhaseForCategory, PhaseException>(phaseForCategory);
            phaseForCategory.SetPhase(this);
            return this;
        }
    }
}
