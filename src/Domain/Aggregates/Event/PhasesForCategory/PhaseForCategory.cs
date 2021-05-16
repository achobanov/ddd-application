using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Domain.Aggregates.Event.PhasesForCategory
{
    public class PhaseForCategory : DomainBase<PhaseForCategoryException>, IPhaseForCategoryState
    {
        private PhaseForCategory()
        {
        }

        public PhaseForCategory(int maxRecoveryTimeInMinutes, int restTimeInMinutes, Category category)
            => this.Validate(() =>
            {
                this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes
                    .IsRequired(nameof(maxRecoveryTimeInMinutes));

                this.RestTimeInMinutes = restTimeInMinutes.IsRequired(nameof(restTimeInMinutes));
                this.Category = category.IsRequired(nameof(category));
            });

        public int MaxRecoveryTimeInMinutes { get; private set; }
        public int RestTimeInMinutes { get; private set; }
        public Category Category { get; private set; }
    }
}
