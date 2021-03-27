using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Gateways.Persistence.Core;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CountryEntity : EntityModel, ICountryState, IMapTo<Country>
    {
        public string IsoCode { get; set; }

        public string Name { get; set; }
    }
}
