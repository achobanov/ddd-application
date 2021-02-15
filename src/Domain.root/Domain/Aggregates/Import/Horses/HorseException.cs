using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Horses
{
    public class HorseException : DomainException
    {
        protected override string Entity { get; } = nameof(Horse);
    }
}
