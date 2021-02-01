using EnduranceContestManager.Gateways.Persistence.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Interfaces
{
    public interface ICommandRepository<in TDataEntry> : IQueryRepository
        where TDataEntry : DataEntry
    {
        Task<int> Save(TDataEntry data, CancellationToken cancellationToken = default);
    }
}
