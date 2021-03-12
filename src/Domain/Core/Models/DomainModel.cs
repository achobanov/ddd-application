using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Core.Exceptions;
using EnduranceJudge.Domain.Core.Validation;
using System;

namespace EnduranceJudge.Domain.Core.Models
{
    public abstract class DomainModel<TException> : IInternalDomainModel
        where TException : DomainException, new()
    {
        protected DomainModel(int id)
        {
            this.Id = id;
        }

        public int Id { get; }

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

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is IDomainModel other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.DomainEquals(other);
        }

        public bool Equals(IDomainModel other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.DomainEquals(other);
        }

        public override int GetHashCode()
            => (this.GetType().ToString() + this.Id).GetHashCode();

        private bool DomainEquals(IDomainModel other)
            => this.Id != default && this.Id == other.Id;
    }
}
