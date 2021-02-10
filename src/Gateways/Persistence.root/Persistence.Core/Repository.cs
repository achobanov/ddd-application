using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class Repository<TDataStore, TDataEntry, TEntity> : ICommandRepository<TEntity>
        where TEntity : IAggregateRoot
        where TDataStore : IDataStore
        where TDataEntry : DataEntry
    {
        protected Repository(TDataStore dataStore)
        {
            this.DataStore = dataStore;
        }

        protected TDataStore DataStore { get; }

        public virtual async Task<TModel> Find<TModel>(int id)
            => await this.DataStore
                .Set<TDataEntry>()
                .Where(x => x.Id == id)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

        public async Task<IList<TModel>> All<TModel>()
            => await this.DataStore
                .Set<TDataEntry>()
                .MapQueryable<TModel>()
                .ToListAsync();

        public async Task<TDataEntry> Find(int id)
            => await this.DataStore.FindAsync<TDataEntry>(id);

        public async Task<int> Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            var dataEntry = await this.DataStore.FindAsync<TDataEntry>(entity.Id);
            if (dataEntry == null)
            {
                dataEntry = entity.Map<TDataEntry>();
                this.DataStore.Add(dataEntry);
            }
            else
            {
                dataEntry.MapFrom(entity);
                this.DataStore.Update(dataEntry);
            }

            await this.DataStore.Commit(cancellationToken);

            return dataEntry.Id;
        }

        protected EntityEntry<TDataEntry> GetTracked(TDataEntry entity)
        {
            if (entity.Id == default)
            {
                return null;
            }

            return this.DataStore
                .ChangeTracker
                .Entries<TDataEntry>()
                .FirstOrDefault(x => x.Entity.Id == entity.Id);
        }
    }
}
