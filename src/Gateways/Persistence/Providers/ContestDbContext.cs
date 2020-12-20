using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Core.Contracts;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Domain.Infrastructure.Entities;

namespace EnduranceContestManager.Gateways.Persistence.Providers
{
    public class ContestDbContext : DbContext, IPersistenceContract
    {
        private readonly IDateTime dateTime;

        public ContestDbContext(DbContextOptions options, IDateTime dateTime)
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
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

#region IPersistenceContract implementation

        IDataSetContext<TEntity> IPersistenceContract.Set<TEntity>()
            => new DataSet<TEntity>(this.Set<TEntity>());

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
            => this.SaveChangesAsync(cancellationToken);

#endregion
    }
}
