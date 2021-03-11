using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Competitions
{
    public class RankingCompetitionException : DomainException
    {
        protected override string Entity { get; } = $"Ranking {nameof(Competition)}";
    }
}
