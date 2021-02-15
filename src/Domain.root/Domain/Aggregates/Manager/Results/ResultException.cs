using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Results
{
    public class ResultException : DomainException
    {
        protected override string Entity { get; } = nameof(Result);
    }
}
