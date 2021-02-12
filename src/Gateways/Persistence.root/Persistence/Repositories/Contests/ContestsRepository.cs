using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Stores;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public class ContestsRepository : StoreRepository<IContestsDataStore, ContestStore, Contest>,
        IContestCommands,
        IContestQueries
    {
        public ContestsRepository(IContestsDataStore dataStore)
            : base(dataStore)
        {
        }

        public override Task<TModel> Find<TModel>(int id)
            => this.DataStore
                .Set<ContestStore>()
                .Where(x => x.Id == id)
                .Include(x => x.Trials)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();
    }
}
