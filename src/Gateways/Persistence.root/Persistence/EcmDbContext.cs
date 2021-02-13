using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Core.Services;
using EnduranceContestManager.Gateways.Persistence.Repositories.Contests;
using EnduranceContestManager.Gateways.Persistence.Stores;

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

        public DbSet<ContestStore> Contests { get; set; }

        public DbSet<TrialStore> Trials { get; set; }

        public DbSet<PhaseStore> Phases { get; set; }

        public DbSet<FinalPhaseStore> FinalPhases { get; set; }

        public DbSet<PhaseForCategoryStore> PhasesForCategories { get; set; }

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
