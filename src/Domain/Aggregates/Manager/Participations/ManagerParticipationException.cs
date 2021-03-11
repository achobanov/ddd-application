using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class ManagerParticipationException : DomainException
    {
        protected override string Entity { get; } = $"Manager {nameof(Participation)}";
    }
}
