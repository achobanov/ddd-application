using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Common.Countries
{
    public interface ICountryState : IDomainModelState
    {
        string IsoCode { get; }

        string Name { get; }
    }
}
