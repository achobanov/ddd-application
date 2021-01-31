using EnduranceContestManager.Application.Interfaces.Core;
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
    public abstract class Repository<TDataStore, TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity>
        where TDataStore : IDataStore
        where TEntity : class, IAggregateRoot
    {
        protected Repository(TDataStore dataStore)
        {
            this.DataStore = dataStore;
        }

        protected TDataStore DataStore { get; }

        public async Task<TModel> Find<TModel>(int id)
            where TModel : IMapFrom<TEntity>
            => await this.DataStore
                .Set<TEntity>()
                .Where(x => x.Id == id)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

        public async Task<IList<TModel>> All<TModel>()
            where TModel : IMapFrom<TEntity>
            => await this.DataStore
                .Set<TEntity>()
                .MapQueryable<TModel>()
                .ToListAsync();

        public async Task<TEntity> Find(int id)
            => await this.DataStore
                .Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = this.DataStore.Update(entity);

            await this.DataStore.Commit(cancellationToken);

            return entry.Entity.Id;
        }

        protected EntityEntry<TEntity> GetTracked(TEntity entity)
        {
            if (entity.Id == default)
            {
                return null;
            }

            return this.DataStore
                .ChangeTracker
                .Entries<TEntity>()
                .FirstOrDefault(x => x.Entity.Id == entity.Id);
        }
    }
}
