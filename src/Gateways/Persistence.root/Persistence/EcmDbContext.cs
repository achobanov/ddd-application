using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Core.Services;
using EnduranceContestManager.Gateways.Persistence.Repositories.Contests;
using EnduranceContestManager.Gateways.Persistence.Entities;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class EcmDbContext : DbContext, IContestsDataStore
    {
        private readonly IBackupService backup;

        public EcmDbContext(DbContextOptions options, IDateTimeService dateTime, IBackupService backup)
            : base(options)
        {
            this.backup = backup;
        }

        public DbSet<ContestEntity> Contests { get; set; }

        public DbSet<TrialEntity> Trials { get; set; }

        public DbSet<PhaseEntity> Phases { get; set; }

        public DbSet<PhaseForCategoryEntity> PhasesForCategories { get; set; }

        public async Task<int> Commit(
            CancellationToken cancellationToken = default,
            bool performBackup = true)
        {
            var result = await this.SaveChangesAsync(cancellationToken);

            if (performBackup)
            {
                await this.backup.Create(this);
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
