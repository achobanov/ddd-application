using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.PhasesForCategory
{
    public class PhaseForCategoryException : DomainException
    {
        protected override string Entity { get; } = nameof(PhaseForCategory);
    }
}
