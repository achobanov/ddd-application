using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Contracts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Blog.Common.Contracts;
using Blog.Domain.Infrastructure.Entities;
using Blog.Domain.Authors;
using Blog.Domain.Articles;
using Blog.Domain.Comments;

namespace Blog.Gateways.Persistence.Providers
{
    public class BlogDbContext : ApiAuthorizationDbContext<IdentityUser>, IPersistenceContract
    {
        private readonly IAuthenticationContext authenticationContext;
        private readonly IDateTime dateTime;

        public BlogDbContext(
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
