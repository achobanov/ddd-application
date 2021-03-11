using EnduranceContestManager.Gateways.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Services
{
    public class SeederService : ISeederService
    {
        private readonly EcmDbContext dbContext;

        public SeederService(EcmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Seed()
        {
            await this.SeedCountries();
        }

        private async Task SeedCountries()
        {
            var countries = new List<CountryEntity>
            {
                new CountryEntity
                {
                    Name = "Bulgaria",
                    IsoCode = "BUL"
                },
            };

            await this.dbContext.AddRangeAsync(countries);
        }
    }
}
