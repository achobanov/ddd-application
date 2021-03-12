﻿using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Core.Services;
using EnduranceJudge.Gateways.Persistence.Entities;
using EnduranceJudge.Gateways.Persistence.Repositories.Contests;

namespace EnduranceJudge.Gateways.Persistence
{
    public class EnduranceJudgeDbContext : DbContext, IContestsDataStore
    {
        private readonly IBackupService backup;

        public EnduranceJudgeDbContext(DbContextOptions options, IDateTimeService dateTime, IBackupService backup)
            : base(options)
        {
            this.backup = backup;
        }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<EventEntity> Contests { get; set; }
        public DbSet<CompetitionEntity> Trials { get; set; }
        public DbSet<PhaseEntity> Phases { get; set; }
        public DbSet<PhaseForCategoryEntity> PhasesForCategories { get; set; }

        public async Task<int> Commit(CancellationToken cancellationToken = default)
        {
            var result = await this.SaveChangesAsync(cancellationToken);

            await this.backup.Create(this);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}