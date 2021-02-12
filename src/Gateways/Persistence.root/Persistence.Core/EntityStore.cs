using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class EntityStore<TEntity> : IMapFrom<TEntity>, IMapTo<TEntity>
        where TEntity : IEntity
    {
        protected EntityStore()
        {
        }

        protected EntityStore(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
