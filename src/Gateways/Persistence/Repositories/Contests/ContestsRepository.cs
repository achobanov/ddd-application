using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Interfaces.Contests;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceJudge.Gateways.Persistence.Repositories.Contests
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
