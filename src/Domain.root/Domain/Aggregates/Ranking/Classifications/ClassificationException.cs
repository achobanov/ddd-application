using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Classifications
{
    public class ClassificationException : DomainException
    {
        protected override string Entity { get; } = nameof(Classification);
    }
}
