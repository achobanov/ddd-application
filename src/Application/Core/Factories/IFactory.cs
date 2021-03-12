using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Application.Core.Factories
{
    public interface IFactory<out TEntity> : IService
    {
        TEntity Create(IDomainModelState state);
    }
}
