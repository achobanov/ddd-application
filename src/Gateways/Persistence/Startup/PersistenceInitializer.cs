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

        public int RunningOrder => 10;

        public void Run(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<EnduranceJudgeDbContext>();

            this.SeedAsync(dbContext);
        }

        private void SeedAsync(EnduranceJudgeDbContext dbContext)
        {
            var hasData = this.backup.Restore(dbContext);

            if (!hasData)
            {
                this.seeder.Seed();
            }

            dbContext.SaveChanges();
        }
    }
}
