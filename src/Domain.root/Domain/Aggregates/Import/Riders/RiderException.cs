using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Import.Riders
{
    public class RiderException : DomainException
    {
        protected override string Entity { get; } = nameof(Rider);
    }
}
