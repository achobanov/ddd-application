using EnduranceContestManager.Application.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Application.Core.Factories
{
    public abstract class Factory<TEntity, TEntityState> : IFactory<TEntity>
        where TEntity : TEntityState
        where TEntityState : IEntityState
    {
        protected abstract TEntity FromState(TEntityState state);

        public TEntity Create(IEntityState state)
        {
            if (state is TEntityState entityState)
            {
                return this.FromState(entityState);
            }

            throw new FactoryException(typeof(TEntity).Name, typeof(TEntityState).Name);
        }
    }
}
