using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Rankings
{
    public class RankingException : DomainException
    {
        protected override string Entity { get; } = nameof(Ranking);
    }
}
