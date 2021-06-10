using EnduranceJudge.Core.Exceptions;
using EnduranceJudge.Core.Models;
using EnduranceJudge.Domain.Core.Exceptions;
using EnduranceJudge.Domain.Core.Validation;
using System;

namespace EnduranceJudge.Domain.Core.Models
{
    public abstract class DomainBase<TException> : ObjectBase, IDomainModel
        where TException : DomainException, new()
    {
        protected DomainBase()
        {
        }

        protected DomainBase(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        internal void Validate(Action action)
        {
            try
            {
                action();
            }
            catch (CoreException exception)
            {
                this.Throw(exception.Message);
            }
        }

        internal void Throw(string message)
            => Thrower.Throw<TException>(message);
    }
}
