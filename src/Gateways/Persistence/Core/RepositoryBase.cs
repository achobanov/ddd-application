using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Gateways.Persistence.Contracts.WorkFile;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Persistence.Core
{
    public class RepositoryBase<TDataStore, TEntityModel, TDomainModel> : ICommandsBase<TDomainModel>
        where TDomainModel : class, IDomainModel
        where TDataStore : IDataStore
        where TEntityModel : EntityBase
    {
        private readonly IWorkFileUpdater workFileUpdater;

        public RepositoryBase(TDataStore dataStore, IWorkFileUpdater workFileUpdater)
        {
            this.workFileUpdater = workFileUpdater;
            this.DataStore = dataStore;
        }

        protected TDataStore DataStore { get; }

        public virtual async Task<TDomainModel> Find(int id)
            => await this.Find<TDomainModel>(id);

        public virtual async Task<TModel> Find<TModel>(int id)
        {
            var model = await this.DataStore
                .Set<TEntityModel>()
                .Where(x => x.Id == id)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

            return model;
        }

        public virtual async Task<IList<TModel>> All<TModel>()
            => await this.DataStore
                .Set<TEntityModel>()
                .MapQueryable<TModel>()
                .ToListAsync();

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

            await this.DataStore.SaveChangesAsync(cancellationToken);
            await this.workFileUpdater.Snapshot();

            return entity.Id;
        }
    }
}
