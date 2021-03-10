using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Competitions
{
    public class ImportCompetitionException : DomainException
    {
        protected override string Entity { get; } = $"Import {nameof(Competition)}";
    }
}
