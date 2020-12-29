using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Gateways.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence.Blog
{
    public interface IBlogDbContext : IDbContext
    {
        public DbSet<Article> Articles { get; }
    }
}
