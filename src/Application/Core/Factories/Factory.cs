using EnduranceJudge.Domain.Core.Exceptions;
using EnduranceJudge.Application.Core.Exceptions;
using EnduranceJudge.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using ValidationResult = IdentityServer4.Validation.ValidationResult;

namespace EnduranceJudge.Application.Core.Factories
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
