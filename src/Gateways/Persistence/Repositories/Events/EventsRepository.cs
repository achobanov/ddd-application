using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Interfaces.Events;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceJudge.Gateways.Persistence.Repositories.Events
{
    internal class EventsRepository : StoreRepository<IEventsDataStore, EventEntity, Event>,
        IEventCommands,
        IEventQueries
    {
        public EventsRepository(IEventsDataStore dataStore)
            : base(dataStore)
        {
        }

        public override Task<TModel> Find<TModel>(int id)
            => this.DataStore
                .Events
                .Where(x => x.Id == id)
                .Include(x => x.Trials)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();
    }
}
