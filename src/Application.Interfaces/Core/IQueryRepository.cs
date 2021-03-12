using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Interfaces.Core
{
    public interface IQueryRepository
    {
        Task<TModel> Find<TModel>(int id);

        Task<IList<TModel>> All<TModel>();
    }
}
