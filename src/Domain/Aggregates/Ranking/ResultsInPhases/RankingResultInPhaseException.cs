using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ResultsInPhases
{
    public class RankingResultInPhaseException : DomainException
    {
        protected override string Entity { get; } = $"Ranking: {nameof(ResultInPhase)}";
    }
}
