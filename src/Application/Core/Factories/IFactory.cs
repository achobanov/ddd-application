using EnduranceContestManager.Core.ConventionalServices;
using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Application.Core.Factories
{
    public interface IFactory<out TEntity> : IService
    {
        TEntity Create(IDomainModelState state);
    }
}
