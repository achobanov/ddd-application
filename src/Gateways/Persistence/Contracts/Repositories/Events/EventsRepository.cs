using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events
{
    internal class EventsRepository : RepositoryBase<IEventsDataStore, EnduranceEventEntity, EnduranceEvent>,
        IEventCommands,
        IEventQueries
    {
        public EventsRepository(
            IEventsDataStore dataStore,
            IWorkFileUpdater workFileUpdater) : base(dataStore, workFileUpdater)
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
