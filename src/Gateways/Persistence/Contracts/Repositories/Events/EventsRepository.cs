using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events
{
    internal class EventsRepository : StoreRepository<IEventsDataStore, EventEntity, Event>,
        IEventCommands,
        IEventQueries
    {
        public EventsRepository(EnduranceJudgeDbContext dataStore) : base(dataStore)
        {
        }

        public override async Task<TModel> Find<TModel>(int id)
        {
            var event_ = await this.DataStore
                .Events
                .Where(x => x.Id == id)
                .Include(x => x.Competitions)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

            return event_;
        }
    }
}
