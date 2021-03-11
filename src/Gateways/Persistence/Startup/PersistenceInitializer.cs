﻿using EnduranceContestManager.Core.Interfaces;
using System;
using System.Threading.Tasks;
using EnduranceContestManager.Gateways.Persistence.Core.Services;
using EnduranceContestManager.Gateways.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnduranceContestManager.Gateways.Persistence.Startup
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
