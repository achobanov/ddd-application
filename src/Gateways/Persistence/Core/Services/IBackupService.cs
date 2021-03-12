using EnduranceJudge.Core.ConventionalServices;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core.Services
{
    public interface IBackupService : IService
    {
        Task Create<TDataStore>(TDataStore dbContext)
            where TDataStore : IDataStore;

        Task Restore<TDataStore>(TDataStore dbContext)
            where TDataStore : DbContext;
    }
}
