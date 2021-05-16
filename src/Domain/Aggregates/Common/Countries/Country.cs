using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Common.Countries
{
    public class Country : DomainBase<CountryException>, ICountryState, IAggregateRoot
    {
        private Country()
        {
        }

        public string IsoCode { get; private set; }

        public string Name { get; private set; }
    }
}
