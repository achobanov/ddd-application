using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Interfaces.Core
{
    public interface IQueryRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TModel> Find<TModel>(int id)
            where TModel : IMapFrom<TEntity>;

        Task<IList<TModel>> All<TModel>()
            where TModel : IMapFrom<TEntity>;
    }
}
