using EnduranceContestManager.Core.ConventionalServices;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core.Services
{
    public interface IBackupService : IService
    {
        Task Create<TDataStore>(TDataStore dbContext)
            where TDataStore : IDataStore;

        Task Restore<TDataStore>(TDataStore dbContext)
            where TDataStore : IDataStore;
    }
}
