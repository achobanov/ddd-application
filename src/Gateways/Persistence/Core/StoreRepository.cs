using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Interfaces.Core;
using EnduranceJudge.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core
{
    internal abstract class StoreRepository<TDataStore, TEntityModel, TDomainModel> : ICommandRepository<TDomainModel>
        where TDomainModel : class, IAggregateRoot
        where TDataStore : IDataStore
        where TEntityModel : EntityModel
    {
        private readonly IMapper mapper;

        protected StoreRepository(TDataStore dataStore, IMapper mapper)
        {
            this.mapper = mapper;
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

        public async Task<int> Save(TDomainModel domainModel, CancellationToken cancellationToken = default)
        {
            var entity = await this.DataStore.FindAsync<TEntityModel>(domainModel.Id);
            if (entity == null)
            {
                entity = domainModel.Map<TEntityModel>();
                this.DataStore.Add(entity);
            }
            else
            {
                entity.MapFrom(domainModel);
                this.DataStore.Update(entity);
            }

            await this.DataStore.Commit(cancellationToken);

            return entity.Id;
        }
    }
}
