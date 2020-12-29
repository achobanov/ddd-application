using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Domain.Infrastructure.Entities;
using EnduranceContestManager.Gateways.Persistence.Blog;
using System;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class EcmDbContext : DbContext, IBlogDbContext
    {
        private readonly IDateTime dateTime;

        public EcmDbContext(DbContextOptions options, IDateTime dateTime)
            : base(options)
            => this.dateTime = dateTime;

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

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
