using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Events
{
    public class ImportEventException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Event)}";
    }
}
