using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
{
    public class ContestException : DomainException
    {
        private static readonly string Name = nameof(Contest);

        protected override string Entity => Name;
    }
}
