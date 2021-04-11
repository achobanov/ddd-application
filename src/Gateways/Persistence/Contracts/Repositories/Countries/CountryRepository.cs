using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Countries
{
    public class CountryRepository : StoreRepository<ICountriesDataStore, CountryEntity, Country>, ICountryQueries
    {
        public CountryRepository(
            ICountriesDataStore dataStore,
            IWorkFileUpdater workFileUpdater) : base(dataStore, workFileUpdater)
        {
        }
    }
}
