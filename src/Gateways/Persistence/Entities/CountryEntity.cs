using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CountryEntity : ICountryState,
        IMap<Country>,
        IMapTo<CountryListingModel>
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IList<AthleteEntity> Athletes { get; set; }
    }
}
