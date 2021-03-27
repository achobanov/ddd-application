using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Phases
{
    public class Phase : DomainModel<PhaseException>, IPhaseState,
        IDependsOn<Competition>
    {
        public Phase(int id, int lengthInKilometers, bool isFinal = false) : base(id)
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
            this.AddRelation(phase => phase.phasesForCategories, phaseForCategory);
            return this;
        }

        public Competition Competition { get; private set; }
        void IDependsOn<Competition>.Set(Competition domainModel)
            => this.Validate(() =>
            {
                this.Competition.IsNotRelated();
                this.Competition = domainModel;
            });
        void IDependsOn<Competition>.Clear(Competition domainModel)
        {
            this.Competition = null;
        }
    }
}
