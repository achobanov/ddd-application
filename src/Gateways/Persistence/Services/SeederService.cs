using EnduranceJudge.Gateways.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Services
{
    public class SeederService : ISeederService
    {
        private readonly EnduranceJudgeDbContext dbContext;

        public SeederService(EnduranceJudgeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            this.SeedCountries();
        }

        private void SeedCountries()
        {
            var countries = new List<CountryEntity>
            {
                new CountryEntity
                {
                    Name = "Bulgaria",
                    IsoCode = "BUL"
                },
            };

            this.dbContext.AddRange(countries);
        }
    }
}
