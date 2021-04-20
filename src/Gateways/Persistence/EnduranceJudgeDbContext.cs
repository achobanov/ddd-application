using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EnduranceJudge.Core.Services;
using EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Countries;
using EnduranceJudge.Gateways.Persistence.Entities;
using EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace EnduranceJudge.Gateways.Persistence
{
    public class EnduranceJudgeDbContext : DbContext,
        IEventsDataStore,
        ICountriesDataStore
    {
        public EnduranceJudgeDbContext()
        {
        }

        public EnduranceJudgeDbContext(DbContextOptions options, IDateTimeService dateTime)
            : base(options)
        {
        }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<CompetitionEntity> Competitions { get; set; }
        public DbSet<PhaseEntity> Phases { get; set; }
        public DbSet<PhaseForCategoryEntity> PhasesForCategories { get; set; }
        public DbSet<PersonnelEntity> Personnel { get; set; }
        public DbSet<AthleteEntity> Athletes { get; set; }
        public DbSet<HorseEntity> Horses { get; set; }
        public DbSet<ParticipantEntity> Participants { get; set; }
        public DbSet<ParticipantInCompetition> ParticipantsInCompetitions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<EventEntity>()
                .HasMany(x => x.Competitions)
                .WithOne(y => y.Event)
                .HasForeignKey(y => y.EventId);

            builder.Entity<EventEntity>()
                .HasMany(x => x.Personnel)
                .WithOne(y => y.Event)
                .HasForeignKey(y => y.EventId);

            builder.Entity<CompetitionEntity>()
                .HasMany(c => c.Phases)
                .WithOne(p => p.Competition)
                .HasForeignKey(p => p.CompetitionId);

            builder.Entity<PhaseEntity>()
                .HasMany(p => p.PhasesForCategories)
                .WithOne(pfc => pfc.Phase)
                .HasForeignKey(pfc => pfc.PhaseId);

            builder.Entity<CompetitionEntity>()
                .HasMany(c => c.ParticipantsInCompetitions)
                .WithOne(pic => pic.Competition)
                .HasForeignKey(pic => pic.CompetitionId);

            builder.Entity<ParticipantEntity>()
                .HasOne(p => p.Horse)
                .WithOne(h => h.Participant)
                .HasForeignKey<HorseEntity>(h => h.ParticipantId);

            builder.Entity<ParticipantEntity>()
                .HasMany(p => p.ParticipantsInCompetitions)
                .WithOne(pic => pic.Participant)
                .HasForeignKey(pic => pic.ParticipantId);

            builder.Entity<ParticipantEntity>()
                .HasOne(p => p.Athlete)
                .WithOne(a => a.Participant)
                .HasForeignKey<AthleteEntity>(a => a.ParticipantId);

            builder.Entity<AthleteEntity>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Athletes)
                .HasForeignKey(a => a.CountryIsoCode);

            builder.Entity<CountryEntity>()
                .HasKey(x => x.IsoCode);

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
