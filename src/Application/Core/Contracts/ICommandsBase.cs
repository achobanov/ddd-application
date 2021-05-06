using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Contracts
{
    public interface ICommandsBase<TDomainModel> : IQueriesBase<TDomainModel>
        where TDomainModel : IAggregateRoot
    {
        Task<int> Save(TDomainModel domainModel, CancellationToken cancellationToken);
    }
}
