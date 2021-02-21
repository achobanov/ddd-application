using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Contests
{
    public class ImportContestException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Contest)}";
    }
}
