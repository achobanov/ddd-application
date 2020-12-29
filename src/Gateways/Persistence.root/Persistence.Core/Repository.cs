using EnduranceContestManager.Application.Interfaces.Base;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class Repository<TDbContext, TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected Repository(TDbContext db)
            => this.Data = db;

        protected TDbContext Data { get; }

        public async Task<TModel> Find<TModel>(int id)
            where TModel : IMapFrom<TEntity>
            => await this.Data
                .Set<TEntity>()
                .Where(x => x.Id == id)
                .Map<TModel>()
                .FirstOrDefaultAsync();

        public async Task<IList<TModel>> All<TModel>()
            where TModel : IMapFrom<TEntity>
            => await this
                .Queryable()
                .Map<TModel>()
                .ToListAsync();

        public async Task<TEntity> Find(int id)
            => await this.Data.FindAsync<TEntity>(id);

        public async Task<int> Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);

            return entry.Entity.Id;
        }

        protected IQueryable<TEntity> Queryable()
            => this.Data.Set<TEntity>();
    }
}