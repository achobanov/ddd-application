using EnduranceJudge.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Interfaces.Core
{
    public interface ICommandRepository<TDomainModel> : IQueryRepository<TDomainModel>
        where TDomainModel : IAggregateRoot
    {
        Task<int> Save(TDomainModel domainModel, CancellationToken cancellationToken = default);
    }
}
