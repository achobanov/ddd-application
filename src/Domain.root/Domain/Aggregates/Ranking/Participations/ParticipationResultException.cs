using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Participations
{
    public class RankingParticipationException : DomainException
    {
        protected override string Entity { get; } = $"Ranking {nameof(Participation)}";
    }
}
