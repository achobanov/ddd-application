using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Events
{
    internal interface IEventsDataStore : IDataStore
    {
        DbSet<EnduranceEventEntity> Events { get; }

        DbSet<CompetitionEntity> Competitions { get; }
    }
}
