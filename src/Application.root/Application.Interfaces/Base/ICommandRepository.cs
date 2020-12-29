using EnduranceContestManager.Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Interfaces.Base
{
    public interface ICommandRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TEntity> Find(int id);

        Task<int> Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}