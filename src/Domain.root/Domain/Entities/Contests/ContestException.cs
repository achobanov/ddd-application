using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Entities.Contests
{
    public class ContestException : DomainException
    {
        private static readonly string Name = nameof(Contest);

        protected override string Entity => Name;
    }
}
