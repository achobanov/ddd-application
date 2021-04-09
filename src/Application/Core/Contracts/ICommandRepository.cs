using EnduranceJudge.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Contracts
{
    public interface ICommandRepository<TDomainModel> : IQueryRepository<TDomainModel>
        where TDomainModel : IAggregateRoot
    {
        Task<int> Save(TDomainModel domainModel, CancellationToken cancellationToken = default);
    }
}
