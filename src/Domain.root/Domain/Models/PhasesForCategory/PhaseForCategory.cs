using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Domain.Models.Phases;
using System.Reflection.Metadata;

namespace EnduranceContestManager.Domain.Models.PhasesForCategory
{
    public class PhaseForCategory : DomainModel, IPhaseForCategoryState, IAggregateRoot
    {
        public PhaseForCategory(
            int id,
            int maxRecoveryTimeInMinutes,
            int restTimeInMinutes,
            Category category,
            int? minSpeedInKilometersPerHour = null,
            int? maxSpeedInKilometersPerHour = null)
            : base(id)
        {
            this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes;
            this.RestTimeInMinutes = restTimeInMinutes;
            this.MinSpeedInKilometersPerHour = minSpeedInKilometersPerHour;
            this.MaxSpeedInKilometersPerHour = maxSpeedInKilometersPerHour;
        }

        public int MaxRecoveryTimeInMinutes { get; private set; }

        public int RestTimeInMinutes { get; private set; }

        public int? MinSpeedInKilometersPerHour { get; private set; }

        public int? MaxSpeedInKilometersPerHour { get; private set; }

        public Phase Phase { get; private set; }

        public Category Category { get; private set; }

        public PhaseForCategory SetPhase(Phase phase)
        {
            this.Phase.CheckNotNullAndSet<Phase, PhaseForCategoryException>(phase);
            return this;
        }

        // public IList<ParticipationInPhase> Participations { get; private set; }
    }
}
