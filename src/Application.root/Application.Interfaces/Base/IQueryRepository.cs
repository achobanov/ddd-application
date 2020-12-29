using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Interfaces.Base
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