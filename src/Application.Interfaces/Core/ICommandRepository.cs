using EnduranceJudge.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Interfaces.Core
{
    public interface ICommandRepository<in TDomainModel> : IQueryRepository
        where TDomainModel : IAggregateRoot
    {
        Task<int> Save(TDomainModel entity, CancellationToken cancellationToken = default);
    }
}
