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
        private const string CannotAddItemTemplate = "Cannot add {0} because entity with Id '{1}' already exists.";
        private const string CannotSetOneToOneRelationTemplate
            = "Cannot set '{0}' relation because it's already set to instance with id: {}";

        public static TValue CheckNotDefault<TValue, TException>(this TValue value, string name = null)
            where TException : DomainException, new()
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                Thrower.Throw<TException>(NotDefaultTemplate, name, value);
            }

            return value;
        }

        public static void CheckNotNullAndSet<TValue, TException>(this TValue @object, TValue value)
            where TException : DomainException, new()
            where TValue : IDomainModel
        {
            if (@object != null)
            {
                Thrower.Throw<TException>(CannotSetOneToOneRelationTemplate, typeof(TValue).Name, @object.Id);
            }

            @object = value;
        }

        public static TEntity CheckNotExistingAndRemove<TEntity, TException>(
            this ICollection<TEntity> collection,
            Func<TEntity, bool> filter)
            where TEntity : IDomainModel
            where TException : DomainException, new()
        {
            var entity = collection.FirstOrDefault(filter);
            if (entity == null)
            {
                Thrower.Throw<TException>(CannotRemoveItemTemplate, typeof(TEntity).Name);
            }

            collection.Remove(entity);
            return entity;
        }

        public static TEntity CheckExistingAndAdd<TEntity, TException>(
            this ICollection<TEntity> collection,
            TEntity entity)
            where TEntity : IDomainModel
            where TException : DomainException, new()
        {
            if (collection.Any(x => x.Id != default && x.Id == entity.Id))
            {
                Thrower.Throw<TException>(CannotAddItemTemplate, typeof(TEntity).Name, entity.Id);
            }

            collection.Add(entity);
            return entity;
        }
    }
}
