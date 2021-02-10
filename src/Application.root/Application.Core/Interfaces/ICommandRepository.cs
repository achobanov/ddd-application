using EnduranceContestManager.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Interfaces
{
    public interface ICommandRepository<in TEntity> : IQueryRepository
        where TEntity : IAggregateRoot
    {
        Task<int> Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
