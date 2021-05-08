using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;

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
    }
}
