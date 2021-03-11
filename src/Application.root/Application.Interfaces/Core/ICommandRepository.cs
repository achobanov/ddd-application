using EnduranceContestManager.Domain.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Interfaces.Core
{
    public interface ICommandRepository<in TDomainModel> : IQueryRepository
        where TDomainModel : IAggregateRoot
    {
        Task<int> Save(TDomainModel entity, CancellationToken cancellationToken = default);
    }
}
