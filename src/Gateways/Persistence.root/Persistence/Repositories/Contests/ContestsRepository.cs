using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public class ContestsRepository : Repository<IContestsDataStore, Contest>,
        IContestCommands,
        IContestQueries
    {
        public ContestsRepository(IContestsDataStore db)
            : base(db)
        {
        }
    }
}
