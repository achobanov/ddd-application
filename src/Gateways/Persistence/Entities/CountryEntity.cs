using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Application.Events.Queries.GetCountriesListing;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class CountryEntity : ICountryState, IMapExplicitly, IMapTo<CountryListingModel>
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IList<AthleteEntity> Athletes { get; set; }

        public void CreateExplicitMap(Profile mapper)
        {
            mapper.CreateMap<CountryEntity, Country>()
                .EqualityComparison((entity, country) => entity.IsoCode == country.IsoCode);

            mapper.CreateMap<Country, CountryEntity>()
                .EqualityComparison((country, entity) => country.IsoCode == entity.IsoCode);
        }
    }
}
