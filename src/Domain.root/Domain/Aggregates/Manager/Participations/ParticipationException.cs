using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class ParticipationException : DomainException
    {
        protected override string Entity { get; } = nameof(Participation);
    }
}
