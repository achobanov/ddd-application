﻿using System;
using System.Threading.Tasks;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Core.Services;
using EnduranceJudge.Gateways.Persistence.Services;
using Microsoft.EntityFrameworkCore;
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
            var dbContext = serviceProvider.GetService<EnduranceJudgeDbContext>();

            await this.SeedAsync(dbContext);
        }

        private async Task SeedAsync(EnduranceJudgeDbContext dbContext)
        {
            await this.backup.Restore(dbContext);

            if (!await dbContext.Contests.AnyAsync())
            {
                await this.seeder.Seed();
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
