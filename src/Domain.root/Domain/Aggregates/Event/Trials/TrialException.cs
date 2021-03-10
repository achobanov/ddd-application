using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.Trials
{
    public class TrialException : DomainException
    {
        protected override string Entity { get; } = nameof(Trial);
    }
}
