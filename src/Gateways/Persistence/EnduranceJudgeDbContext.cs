using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Core.Services;
using EnduranceJudge.Gateways.Persistence.Entities;
using EnduranceJudge.Gateways.Persistence.Repositories.Events;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace EnduranceJudge.Gateways.Persistence
{
    public class EnduranceJudgeDbContext : DbContext, IEventsDataStore
    {
        private readonly IBackupService backup;

        public EnduranceJudgeDbContext()
        {
        }

        public EnduranceJudgeDbContext(DbContextOptions options, IDateTimeService dateTime, IBackupService backup)
            : base(options)
        {
            this.backup = backup;
        }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<CompetitionEntity> Competitions { get; set; }
        public DbSet<PhaseEntity> Phases { get; set; }
        public DbSet<PhaseForCategoryEntity> PhasesForCategories { get; set; }

        public async Task<int> Commit(CancellationToken cancellationToken = default)
        {
            var result = await this.SaveChangesAsync(cancellationToken);

            // await this.backup.Create(this);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Ignore<Domain.Aggregates.Event.Competitions.Competition>();

            builder.Entity<EventEntity>()
                .HasMany(x => x.Competitions)
                .WithOne(y => y.Event)
                .HasForeignKey(y => y.EventId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
