using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Core.Validation
{
    public static class ValidationExtensions
    {
        private const string NotDefaultTemplate = "Property '{0}' cannot be '{1}'";
        private const string CannotRemoveItemTemplate = "Cannot remove {0} because it is not found.";

        public static TValue CheckNotDefault<TValue, TException>(this TValue value, string name = null)
            where TException : DomainException, new()
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                Thrower.Throw<TException>(NotDefaultTemplate, name, value);
            }

            return value;
        }

        public static TEntity CheckAndRemove<TEntity, TException>(
            this ICollection<TEntity> collection,
            Func<TEntity, bool> filter)
            where TEntity : IEntity
            where TException : DomainException, new()
        {
            var item = collection.FirstOrDefault(filter);
            if (item == null)
            {
                Thrower.Throw<TException>(CannotRemoveItemTemplate, typeof(TEntity).Name);
            }

            collection.Remove(item);
            return item;
        }
    }
}
