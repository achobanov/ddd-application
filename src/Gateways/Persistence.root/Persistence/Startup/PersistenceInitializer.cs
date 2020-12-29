using System;
using System.Linq;
using System.Threading.Tasks;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Persistence.Startup
{
    public class PersistenceInitializer : IInitializerInterface
    {
        public async Task Run(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<EcmDbContext>();

            await this.SeedAsync(dbContext);
        }

        private async Task SeedAsync(EcmDbContext data)
        {
            if (data.Articles.Any())
            {
                return;
            }

            var article = new Article("Test Article", "Test Article Content")
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now,
            };

            await data.Articles.AddAsync(article);
            await data.SaveChangesAsync();
        }
    }
}
