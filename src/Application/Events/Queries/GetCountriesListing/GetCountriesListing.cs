using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Application.Core.Handlers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Queries.GetCountriesListing
{
    public class GetCountriesListing : IRequest<IEnumerable<CountryListingModel>>
    {
        public class GetCountriesListingHandler : Handler<GetCountriesListing, IEnumerable<CountryListingModel>>
        {
            private readonly ICountryQueries countryQueries;

            public GetCountriesListingHandler(ICountryQueries countryQueries)
            {
                this.countryQueries = countryQueries;
            }

            public override async Task<IEnumerable<CountryListingModel>> Handle(
                GetCountriesListing request,
                CancellationToken cancellationToken)
            {
                var countries = await this.countryQueries.GetAll<CountryListingModel>();
                return countries;
            }
        }
    }
}
