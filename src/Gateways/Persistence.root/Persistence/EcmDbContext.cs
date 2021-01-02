using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Domain.Blog.Articles;
using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Gateways.Persistence.Blog;
using EnduranceContestManager.Gateways.Persistence.Core.Services;
using System;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class EcmDbContext : DbContext, IBlogDbContext
    {
        private readonly IDateTimeService dateTime;
        private readonly IBackupService backup;

        public EcmDbContext(DbContextOptions options, IDateTimeService dateTime, IBackupService backup)
            : base(options)
        {
            this.dateTime = dateTime;
            this.backup = backup;
        }

        public DbSet<Article> Articles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = this.dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = this.dateTime.Now;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var result = base.SaveChangesAsync(cancellationToken);

            this.backup.Create(this);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
