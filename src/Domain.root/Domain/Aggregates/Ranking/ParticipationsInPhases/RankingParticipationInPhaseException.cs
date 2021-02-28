using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.ParticipationsInPhases
{
    public class RankingParticipationInPhaseException : DomainException
    {
        protected override string Entity { get; } = $"Ranking {nameof(ParticipationInPhase)}";
    }
}
