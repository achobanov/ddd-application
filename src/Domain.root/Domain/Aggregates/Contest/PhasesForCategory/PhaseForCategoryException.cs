using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Contest.PhasesForCategory
{
    public class PhaseForCategoryException : DomainException
    {
        protected override string Entity { get; } = nameof(PhaseForCategory);
    }
}
