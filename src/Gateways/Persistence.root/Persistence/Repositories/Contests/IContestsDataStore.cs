using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public interface IContestsDataStore : IDataStore
    {
        public DbSet<ContestData> Contests { get; }
    }
}
