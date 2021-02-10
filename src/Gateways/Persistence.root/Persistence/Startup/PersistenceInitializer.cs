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

            await dbContext.Commit(performBackup: false);
        }
    }
}
