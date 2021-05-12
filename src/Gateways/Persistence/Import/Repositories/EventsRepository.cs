using EnduranceJudge.Application.Import.Contracts;
using EnduranceJudge.Domain.Aggregates.Import.EnduranceEvents;
using EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;

namespace EnduranceJudge.Gateways.Persistence.Import.Repositories
{
    internal class EventsRepository : RepositoryBase<IEnduranceEventsDataStore, EnduranceEventEntity, EnduranceEvent>,
        IEventCommands
    {
        public EventsRepository(IEnduranceEventsDataStore dataStore, IWorkFileUpdater workFileUpdater)
            : base(dataStore, workFileUpdater)
        {
        }
    }
}
