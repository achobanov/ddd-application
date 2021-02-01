using EnduranceContestManager.Domain.Entities.Contests;
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
            await this.backup.Restore(dbContext);

            if (dbContext.Contests.Any())
            {
                return;
            }

            // TODO: Move seed entities in Domain.
            var contest = new Contest(
                1,
                "Default contest",
                "Default Populated place",
                "Bulgaria",
                "Default Mr President",
                "Default Fei tech",
                "Default Fei Vet",
                "Default Mr Vet President",
                "Default Foreign Judge",
                "Default Active vet");
                // new List<string> { "Default Vet committee member 1", "Default Vet committee member 2" },
                // new List<string> { "Default Judge committee member 1", "Default Judge committee member 2" },
                // new List<string> { "Default steward 1", "Default steward 2" });

            await dbContext.AddAsync(contest);

            await dbContext.Commit(performBackup: false);
        }
    }
}
