using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Common.Countries
{
    public class Country : DomainModel<CountryException>, ICountryState
    {
        private Country(int id) : base(id)
        {
        }

        public string IsoCode { get; }

        public string Name { get; }
    }
}
