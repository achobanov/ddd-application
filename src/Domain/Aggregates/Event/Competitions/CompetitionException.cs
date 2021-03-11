using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.Competitions
{
    public class CompetitionException : DomainException
    {
        protected override string Entity { get; } = nameof(Competition);
    }
}
