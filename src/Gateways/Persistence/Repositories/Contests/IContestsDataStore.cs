using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public interface IContestsDataStore : IDataStore
    {
        public DbSet<EventEntity> Contests { get; }

        public DbSet<CompetitionEntity> Trials { get; }
    }
}
