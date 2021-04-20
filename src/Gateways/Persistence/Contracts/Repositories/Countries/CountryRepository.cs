using EnduranceJudge.Application.Contracts.Countries;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Countries
{
    public class CountryRepository : ICountryQueries
    {
        private readonly EnduranceJudgeDbContext dbContext;

        public CountryRepository(EnduranceJudgeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Country> Find(string isoCode)
        {
            var country = await this.dbContext
                .Countries
                .Where(c => c.IsoCode == isoCode)
                .MapQueryable<Country>()
                .FirstOrDefaultAsync();

            return country;
        }
    }
}
