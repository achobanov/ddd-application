using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Common.Contracts;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Domain.Authors;
using EnduranceContestManager.Domain.Comments;
using EnduranceContestManager.Domain.Infrastructure.Entities;

namespace EnduranceContestManager.Gateways.Persistence.Providers
{
    public class EnduranceContestManagerDbContext : ApiAuthorizationDbContext<IdentityUser>, IPersistenceContract
    {
        private readonly IAuthenticationContext authenticationContext;
        private readonly IDateTime dateTime;

        public EnduranceContestManagerDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IAuthenticationContext authenticationContext,
            IDateTime dateTime)
            : base(options, operationalStoreOptions)
        {
            this.authenticationContext = authenticationContext;
            this.dateTime = dateTime;
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy ??= this.authenticationContext.Username;
                        entry.Entity.CreatedOn = this.dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = this.authenticationContext.Username;
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
