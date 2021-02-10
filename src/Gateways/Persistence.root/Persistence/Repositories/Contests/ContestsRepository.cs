using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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

        public override Task<TModel> Find<TModel>(int id)
            => this.DataStore
                .Set<ContestData>()
                .Where(x => x.Id == id)
                .Include(x => x.Trials)
                .ThenInclude(x => x.Contest)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();
    }
}
