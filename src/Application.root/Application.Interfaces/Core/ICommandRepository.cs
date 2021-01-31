using EnduranceContestManager.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Interfaces.Core
{
    public interface ICommandRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TEntity> Find(int id);

        Task<int> Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
