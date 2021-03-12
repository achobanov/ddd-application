using EnduranceJudge.Domain.Core.Exceptions;

namespace EnduranceJudge.Domain.Aggregates.Import.Athletes
{
    public class RiderException : DomainException
    {
        protected override string Entity { get; } = nameof(Athlete);
    }
}
