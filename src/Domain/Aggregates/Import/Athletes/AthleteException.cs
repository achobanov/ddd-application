using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Athletes
{
    public class RiderException : DomainException
    {
        protected override string Entity { get; } = nameof(Athlete);
    }
}
