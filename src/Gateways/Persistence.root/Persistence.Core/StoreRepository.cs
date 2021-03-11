using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class StoreRepository<TDataStore, TEntityModel, TDomainModel> : ICommandRepository<TDomainModel>
        where TDomainModel : IAggregateRoot
        where TDataStore : IDataStore
        where TEntityModel : EntityModel<TDomainModel>
    {
        protected StoreRepository(TDataStore dataStore)
        {
            this.DataStore = dataStore;
        }

        protected TDataStore DataStore { get; }

        public virtual async Task<TModel> Find<TModel>(int id)
            => await this.DataStore
                .Set<TEntityModel>()
                .Where(x => x.Id == id)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

        public virtual async Task<IList<TModel>> All<TModel>()
            => await this.DataStore
                .Set<TEntityModel>()
                .MapQueryable<TModel>()
                .ToListAsync();

        public virtual async Task<TEntityModel> Find(int id)
            => await this.DataStore.FindAsync<TEntityModel>(id);

        public async Task<int> Save(TDomainModel entity, CancellationToken cancellationToken = default)
        {
            var dataEntry = await this.DataStore.FindAsync<TEntityModel>(entity.Id);
            if (dataEntry == null)
            {
                dataEntry = entity.Map<TEntityModel>();
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
    }
}
