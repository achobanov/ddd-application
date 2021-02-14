using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain
{
    public abstract class DomainModel<TException> : IDomainModel
        where TException : DomainException, new()
    {
        protected DomainModel(int? id)
        {
            this.Id = id ?? default;
        }

        public int Id { get; private set; }

        internal void Add<TPrincipal, TDependant>(
            TPrincipal principal,
            Func<TPrincipal, List<TDependant>> collectionSelector,
            TDependant dependant)
            where TPrincipal : DomainModel<TException>
            where TDependant : class, IDependsOn<TPrincipal>
        {
            this.Except(() =>
            {
                collectionSelector(principal).CheckExistingAndAdd(dependant);
                dependant.Set(principal);
            });
        }

        internal void Remove<TPrincipal, TDependant>(
            TPrincipal principal,
            Func<TPrincipal, List<TDependant>> collectionSelector,
            TDependant dependant)
            where TPrincipal : DomainModel<TException>
            where TDependant : class, IDependsOn<TPrincipal>
        {
            this.Except(() =>
            {
                collectionSelector(principal).CheckNotExistingAndRemove(dependant);
                dependant.Clear(principal);
            });
        }

        internal void Set<TPrincipal, TDependant>(
            TPrincipal principal,
            Func<TPrincipal, TDependant> selector,
            Action<TPrincipal, TDependant> assigner,
            TDependant dependant)
            where TPrincipal : DomainModel<TException>
            where TDependant : class, IDependsOn<TPrincipal>
        {
            this.Except(() =>
            {
                var existing = selector(principal);
                existing?.Clear(principal);

                assigner(principal, dependant);
                dependant.Set(principal);
            });
        }

        internal void Clear<TPrincipal, TDependant>(
            TPrincipal principal,
            Func<TPrincipal, TDependant> selector,
            Action<TPrincipal, TDependant> assigner)
            where TPrincipal : DomainModel<TException>
            where TDependant : class, IDependsOn<TPrincipal>
        {
            this.Except(() =>
            {
                var existingDependant = selector(principal);
                if (existingDependant != null)
                {
                    existingDependant.Clear(principal);
                    assigner(principal, null);
                }
            });
        }

        protected void Except(Action action)
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
