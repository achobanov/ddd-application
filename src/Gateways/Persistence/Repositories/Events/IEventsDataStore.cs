using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceJudge.Gateways.Persistence.Repositories.Events
{
    internal interface IEventsDataStore : IDataStore
    {
        DbSet<EventEntity> Events { get; }

        DbSet<CompetitionEntity> Competitions { get; }
    }
}