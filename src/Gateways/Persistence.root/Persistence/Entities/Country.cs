using EnduranceContestManager.Domain.Aggregates.Common.Countries;
using EnduranceContestManager.Gateways.Persistence.Core;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class CountryEntity : EntityModel<Country>, ICountryState
    {
        public string IsoCode { get; set; }

        public string Name { get; set; }
    }
}
