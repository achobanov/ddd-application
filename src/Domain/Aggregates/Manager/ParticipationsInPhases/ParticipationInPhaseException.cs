using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases
{
    public class ParticipationInPhaseException : DomainException
    {
        protected override string Entity { get; } = nameof(ParticipationInPhase);
    }
}
