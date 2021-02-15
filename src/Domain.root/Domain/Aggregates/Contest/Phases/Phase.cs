using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory;
using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Phases
{
    public class Phase : DomainModel<PhaseException>, IPhaseState, IAggregateRoot,
        IDependsOn<Trial>
    {
        public Phase(int id, int lengthInKilometers)
            : base(id)
        {
            this.Except(() =>
            {
                this.LengthInKilometers = lengthInKilometers.IsRequired(nameof(lengthInKilometers));
            });
        }

        public int LengthInKilometers { get; private set; }

        public bool IsFinal { get; private set; }

        public List<PhaseForCategory> PhasesForCategories { get; private set; } = new();

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
