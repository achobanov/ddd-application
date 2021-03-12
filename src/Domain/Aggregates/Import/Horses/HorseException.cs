using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Import.Horses
{
    public class HorseException : DomainException
    {
        protected override string Entity { get; } = nameof(Horse);
    }
}
