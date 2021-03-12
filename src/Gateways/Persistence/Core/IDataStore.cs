using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core
{
    public interface IDataStore
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        EntityEntry<TEntity> Add<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity)
            where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValuePairs)
            where TEntity : class;

        Task<int> Commit(CancellationToken cancellationToken = default, bool performBackup = true);
    }
}
