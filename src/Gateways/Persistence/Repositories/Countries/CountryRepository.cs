using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;

namespace EnduranceJudge.Gateways.Persistence.Repositories.Countries
{
    public class CountryRepository : StoreRepository<EnduranceJudgeDbContext, CountryEntity, Country>, ICountryQueries
    {
        public CountryRepository(EnduranceJudgeDbContext dataStore) : base(dataStore)
        {
        }
    }
}
