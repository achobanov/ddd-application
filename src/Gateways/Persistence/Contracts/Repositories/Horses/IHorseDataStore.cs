using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnduranceJudge.Gateways.Persistence.Contracts.Repositories.Horses
{
    public interface IHorseDataStore : IDataStore
    {
        public DbSet<HorseEntity> Horses { get; }
    }
}
