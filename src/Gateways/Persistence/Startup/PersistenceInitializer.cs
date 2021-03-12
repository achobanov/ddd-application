using System;
using System.Threading.Tasks;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Core.Services;
using EnduranceJudge.Gateways.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceJudge.Gateways.Persistence.Startup
{
    public class PersistenceInitializer : IInitializerInterface
    {
        private readonly IBackupService backup;
        private readonly ISeederService seeder;

        public PersistenceInitializer(IBackupService backup, ISeederService seeder)
        {
            this.backup = backup;
            this.seeder = seeder;
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
