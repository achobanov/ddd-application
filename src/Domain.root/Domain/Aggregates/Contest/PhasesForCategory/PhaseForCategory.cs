using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Domain.Aggregates.Contest.Phases;

namespace EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory
{
    public class PhaseForCategory : DomainModel<PhaseForCategoryException>, IPhaseForCategoryState, IAggregateRoot,
        IDependsOn<Phase>
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
            this.Except(() =>
            {
                this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes
                    .IsRequired(nameof(MaxRecoveryTimeInMinutes));

                this.RestTimeInMinutes = restTimeInMinutes.IsRequired(nameof(restTimeInMinutes));
                this.Category = category.IsRequired(nameof(category));
            });

            this.MinSpeedInKilometersPerHour = minSpeedInKilometersPerHour;
            this.MaxSpeedInKilometersPerHour = maxSpeedInKilometersPerHour;
        }

        public int MaxRecoveryTimeInMinutes { get; private set; }

        public int RestTimeInMinutes { get; private set; }

        public int? MinSpeedInKilometersPerHour { get; private set; }

        public int? MaxSpeedInKilometersPerHour { get; private set; }

        public Phase Phase { get; private set; }

        public Category Category { get; private set; }

        // public IList<ParticipationInPhase> Participations { get; private set; }
        void IDependsOn<Phase>.Set(Phase domainModel)
            => this.Except(() =>
            {
                this.Phase.CheckNotRelated();
                this.Phase = domainModel;
            });

        void IDependsOn<Phase>.Clear(Phase domainModel)
        {
            this.Phase = null;
        }
    }
}
