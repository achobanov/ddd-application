using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;

namespace EnduranceContestManager.Domain
{
    public abstract class DomainModel<TException> : IInternalDomainModel
        where TException : DomainException, new()
    {
        protected DomainModel(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        void IInternalDomainModel.Validate(Action action)
            => this.Validate(action);

        internal void Validate(Action action)
        {
            try
            {
                action();
            }
            catch (ValidationException invalid)
            {
                Thrower.Throw<TException>(invalid.Message);
            }
        }
    }
}
