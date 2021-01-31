using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public interface IContestsDataStore : IDataStore
    {
        public DbSet<Contest> Contests { get; }
    }
}
