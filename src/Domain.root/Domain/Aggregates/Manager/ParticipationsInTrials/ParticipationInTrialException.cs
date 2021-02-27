using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInTrials
{
    public class ParticipationInTrialException : DomainException
    {
        protected override string Entity { get; } = $"Manager {nameof(ParticipationInTrial)}";
    }
}
