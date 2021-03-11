using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInCompetitions
{
    public class ParticipationInCompetitionException : DomainException
    {
        protected override string Entity { get; } = $"Manager {nameof(ParticipationInCompetition)}";
    }
}
