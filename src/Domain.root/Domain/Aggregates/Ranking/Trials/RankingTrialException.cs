using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Trials
{
    public class RankingTrialException : DomainException
    {
        protected override string Entity { get; } = $"Ranking {nameof(Trial)}";
    }
}
