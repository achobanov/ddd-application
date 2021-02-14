using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Models.ImportAggregate.Riders
{
    public class RiderException : DomainException
    {
        protected override string Entity { get; } = nameof(Rider);
    }
}
