using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Phases
{
    public class Phase : DomainBase<PhaseException>, IPhaseState
    {
        private Phase()
        {
        }

        public Phase(int lengthInKilometers, bool isFinal = false)
            => this.Validate(() =>
            {
                this.IsFinal = isFinal;
                this.LengthInKilometers = lengthInKilometers.IsRequired(nameof(lengthInKilometers));
            });

        public bool IsFinal { get; private set; }
        public int LengthInKilometers { get; private set; }


        private List<PhaseForCategory> phasesForCategories = new();
        public IReadOnlyList<PhaseForCategory> PhasesForCategories
        {
            get => this.phasesForCategories.AsReadOnly();
            private set => this.phasesForCategories = value.ToList();
        }
        public Phase Add(PhaseForCategory phaseForCategory)
        {
            this.phasesForCategories.ValidateAndAddOrUpdate(phaseForCategory);
            return this;
        }
    }
}
