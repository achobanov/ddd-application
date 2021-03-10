using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceContestManager.Domain.Aggregates.Event.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Event.Phases
{
    public class Phase : DomainModel<PhaseException>, IPhaseState,
        IDependsOn<Trial>
    {
        public Phase(int id, int lengthInKilometers, bool isFinal = false) : base(id)
            => this.Validate(() =>
            {
                this.IsFinal = isFinal;
                this.LengthInKilometers = lengthInKilometers.IsRequired(nameof(lengthInKilometers));
            });

        public bool IsFinal { get; private set; }
        public int LengthInKilometers { get; private set; }


        private readonly List<PhaseForCategory> phasesForCategories = new();
        public IReadOnlyList<PhaseForCategory> PhasesForCategories => this.phasesForCategories.AsReadOnly();
        public Phase AddCategory(PhaseForCategory phaseForCategory)
        {
            this.Add(phase => phase.phasesForCategories, phaseForCategory);
            return this;
        }

        public Trial Trial { get; private set; }
        void IDependsOn<Trial>.Set(Trial domainModel)
            => this.Validate(() =>
            {
                this.Trial.IsNotRelated();
                this.Trial = domainModel;
            });
        void IDependsOn<Trial>.Clear(Trial domainModel)
        {
            this.Trial = null;
        }
    }
}
