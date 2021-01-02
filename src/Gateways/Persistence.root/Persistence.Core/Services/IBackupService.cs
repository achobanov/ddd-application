using EnduranceContestManager.Core.ConventionalServices;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core.Services
{
    public interface IBackupService : IService
    {
        Task Create<TDbContext>(TDbContext dbContext)
            where TDbContext : IDbContext;

        Task Restore<TDbContext>(TDbContext dbContext)
            where TDbContext : IDbContext;
    }
}