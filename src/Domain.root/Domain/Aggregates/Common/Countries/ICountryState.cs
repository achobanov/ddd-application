using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Common.Countries
{
    public interface ICountryState : IDomainModel
    {
        string IsoCode { get; }

        string Name { get; }
    }
}
