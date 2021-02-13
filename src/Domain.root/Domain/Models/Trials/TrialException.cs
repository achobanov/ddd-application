using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Models.Trials
{
    public class TrialException : DomainException
    {
        protected override string Entity { get; } = nameof(Trial);
    }
}
