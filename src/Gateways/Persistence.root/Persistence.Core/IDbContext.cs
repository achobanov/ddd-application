using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity)
            where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValuePairs)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}