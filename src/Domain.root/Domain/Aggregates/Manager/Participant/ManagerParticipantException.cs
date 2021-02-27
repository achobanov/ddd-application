using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participant
{
    public class ManagerParticipantException : DomainException
    {
        protected override string Entity { get; } = $"Manager {nameof(Participant)}";
    }
}
