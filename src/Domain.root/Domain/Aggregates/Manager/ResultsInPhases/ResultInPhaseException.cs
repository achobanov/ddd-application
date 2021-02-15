using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
{
    public class ResultInPhaseException : DomainException
    {
        protected override string Entity { get; } = nameof(ResultInPhase);
    }
}
