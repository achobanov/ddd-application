using EnduranceJudge.Application.Import.Contracts;
using EnduranceJudge.Domain.Aggregates.Import.Events;
using EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;

namespace EnduranceJudge.Gateways.Persistence.Import.Repositories
{
    internal class EventsRepository : RepositoryBase<IEventsDataStore, EventEntity, Event>,
        IEventCommands
    {
        public EventsRepository(IEventsDataStore dataStore, IWorkFileUpdater workFileUpdater)
            : base(dataStore, workFileUpdater)
        {
        }
    }
}
