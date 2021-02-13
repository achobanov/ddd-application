using EnduranceContestManager.Application.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Application.Core.Factories
{
    public abstract class Factory<TDomainModel, TDomainModelState> : IFactory<TDomainModel>
        where TDomainModel : TDomainModelState
        where TDomainModelState : IDomainModelState
    {
        protected abstract TDomainModel FromState(TDomainModelState state);

        public TDomainModel Create(IDomainModelState state)
        {
            if (state is TDomainModelState entityState)
            {
                return this.FromState(entityState);
            }

            throw new FactoryException(typeof(TDomainModel).Name, typeof(TDomainModelState).Name);
        }
    }
}
