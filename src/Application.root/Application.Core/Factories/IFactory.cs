using EnduranceContestManager.Core.ConventionalServices;
using EnduranceContestManager.Domain.Interfaces;

namespace EnduranceContestManager.Application.Core.Factories
{
    public interface IFactory<out TEntity> : IService
    {
        TEntity Create(IEntityState state);
    }
}
