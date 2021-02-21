using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Phases
{
    public class Phase : DomainModel<PhaseException>, IPhaseState,
        IDependsOn<Trial>
    {
        public Phase(int id, int lengthInKilometers, bool isFinal = false) : base(id)
            => this.Except(() =>
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
            => this.Except(() =>
            {
                this.Trial.CheckNotRelated();
                this.Trial = domainModel;
            });
        void IDependsOn<Trial>.Clear(Trial domainModel)
        {
            this.Trial = null;
        }
    }
}
