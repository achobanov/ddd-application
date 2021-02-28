using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Common.Countries
{
    public interface ICountryState : IDomainModelState
    {
        string IsoCode { get; }

        string Name { get; }
    }
}
