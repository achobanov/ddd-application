using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceJudge.Gateways.Persistence.Repositories.Contests
{
    public interface IContestsDataStore : IDataStore
    {
        public DbSet<EventEntity> Contests { get; }

        public DbSet<CompetitionEntity> Trials { get; }
    }
}
