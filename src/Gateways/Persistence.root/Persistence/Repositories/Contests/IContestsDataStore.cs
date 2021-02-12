using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Stores;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public interface IContestsDataStore : IDataStore
    {
        public DbSet<ContestStore> Contests { get; }

        public DbSet<TrialStore> Trials { get; }
    }
}
