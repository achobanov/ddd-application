using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class EntityModel<TEntity> : IMapFrom<TEntity>, IMapTo<TEntity>
        where TEntity : IDomainModel
    {
        protected EntityModel()
        {
        }

        protected EntityModel(int id)
        {
            this.Id = id;
        }

        [Key]
        public int Id { get; set; }
    }
}
