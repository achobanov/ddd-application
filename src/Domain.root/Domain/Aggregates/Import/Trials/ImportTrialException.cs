using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Trials
{
    public class ImportTrialException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Trial)}";
    }
}
