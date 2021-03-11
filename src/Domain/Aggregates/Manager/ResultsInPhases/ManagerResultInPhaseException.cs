using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
{
    public class ManagerResultInPhaseException : DomainException
    {
        protected override string Entity { get; } = $"Manager {nameof(ResultInPhase)}";
    }
}
