using EnduranceJudge.Core.ConventionalServices;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core.Services
{
    public interface IBackupService : IService
    {
        Task Create<TDataStore>(TDataStore dbContext)
            where TDataStore : IDataStore;

        bool Restore<TDataStore>(TDataStore dbContext)
            where TDataStore : DbContext;
    }
}
