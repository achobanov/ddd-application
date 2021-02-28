using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Domain.Aggregates.Contest.Phases;

namespace EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory
{
    public class PhaseForCategory : DomainModel<PhaseForCategoryException>, IPhaseForCategoryState,
        IDependsOn<Phase>
    {
        public PhaseForCategory(
            int id,
            int maxRecoveryTimeInMinutes,
            int restTimeInMinutes,
            Category category)
            : base(id)
        {
            this.Validate(() =>
            {
                this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes
                    .IsRequired(nameof(maxRecoveryTimeInMinutes));

                this.RestTimeInMinutes = restTimeInMinutes.IsRequired(nameof(restTimeInMinutes));
                this.Category = category.IsRequired(nameof(category));
            });
        }

        public int MaxRecoveryTimeInMinutes { get; private set; }
        public int RestTimeInMinutes { get; private set; }
        public Category Category { get; private set; }

        public Phase Phase { get; private set; }
        void IDependsOn<Phase>.Set(Phase domainModel)
            => this.Validate(() =>
            {
                this.Phase.IsNotRelated();
                this.Phase = domainModel;
            });
        void IDependsOn<Phase>.Clear(Phase domainModel)
        {
            this.Phase = null;
        }
    }
}
