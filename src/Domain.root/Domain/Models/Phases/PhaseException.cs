using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Models.Phases
{
    public class PhaseException : DomainException
    {
        protected override string Entity { get; } = nameof(Phase);
    }
}
