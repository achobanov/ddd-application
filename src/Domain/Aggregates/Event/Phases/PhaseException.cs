using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.Phases
{
    public class PhaseException : DomainException
    {
        protected override string Entity { get; } = nameof(Phase);
    }
}
