using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public class ContestsRepository : Repository<IContestsDataStore, ContestData>,
        IContestCommands,
        IContestQueries
    {
        public ContestsRepository(IContestsDataStore db)
            : base(db)
        {
        }
    }
}
