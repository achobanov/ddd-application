using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public class ParticipantException : DomainException
    {
        protected override string Entity { get; } = nameof(Participant);
    }
}
