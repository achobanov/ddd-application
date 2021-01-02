using EnduranceContestManager.Domain.Blog.Articles;
using System;
using System.Linq;
using System.Threading.Tasks;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Persistence.Startup
{
    public class PersistenceInitializer : IInitializerInterface
    {
        private readonly IBackupService backup;

        public PersistenceInitializer(IBackupService backup)
        {
            this.backup = backup;
        }

        public async Task Run(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<EcmDbContext>();

            await this.SeedAsync(dbContext);
        }

        private async Task SeedAsync(EcmDbContext dbContext)
        {
            if (dbContext.Articles.Any())
            {
                return;
            }

            var article = new Article("Test Article", "Test Article Content")
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now,
                CreatedBy = "Me",
            };

            await dbContext.Articles.AddAsync(article);
            // await this.backup.Restore(dbContext);
            await dbContext.SaveChangesAsync();

            await this.backup.Create(dbContext);
        }
    }
}
