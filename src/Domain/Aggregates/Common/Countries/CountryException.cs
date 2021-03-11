using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Common.Countries
{
    public class CountryException : DomainException
    {
        protected override string Entity { get; } = nameof(Country);
    }
}
