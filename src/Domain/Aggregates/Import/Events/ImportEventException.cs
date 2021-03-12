using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Import.Events
{
    public class ImportEventException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Event)}";
    }
}
