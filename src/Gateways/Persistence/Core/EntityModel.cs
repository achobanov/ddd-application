using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EnduranceJudge.Gateways.Persistence.Core
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
