using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Core.Validation;

namespace EnduranceJudge.Domain.Aggregates.Common.Countries
{
    public class Country : DomainModel<CountryException>, ICountryState, IAggregateRoot
    {
        private Country() : base(default)
        {
        }

        internal Country(string isoCode) : base(default)
            => this.Validate(() =>
            {
                this.IsoCode = isoCode.IsRequired(nameof(isoCode));
            });

        public string IsoCode { get; private set; }

        public string Name { get; private set; }
    }
}
