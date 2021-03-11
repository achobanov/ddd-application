using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Aggregates.Event.Events;
using EnduranceContestManager.Gateways.Persistence.Core;
using EnduranceContestManager.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceContestManager.Gateways.Persistence.Repositories.Contests
{
    public class ContestsRepository : StoreRepository<IContestsDataStore, EventEntity, Event>,
        IContestCommands,
        IContestQueries
    {
        public ContestsRepository(IContestsDataStore dataStore)
            : base(dataStore)
        {
        }

        public override Task<TModel> Find<TModel>(int id)
            => this.DataStore
                .Set<EventEntity>()
                .Where(x => x.Id == id)
                .Include(x => x.Trials)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();
    }
}
