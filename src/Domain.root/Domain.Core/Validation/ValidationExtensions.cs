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

        public static TValue CheckNotNullAndSet<TValue, TException>(this TValue obj, TValue value)
            where TException : DomainException, new()
            where TValue : IDomainModel
        {
            if (obj != null)
            {
                Thrower.Throw<TException>(CannotSetOneToOneRelationTemplate, typeof(TValue).Name, obj.Id);
            }

            obj = value;

            return value;
        }

        public static TDomainModel CheckNotExistingAndRemove<TDomainModel, TException>(
            this ICollection<TDomainModel> collection,
            TDomainModel model)
            where TDomainModel : IDomainModel
            where TException : DomainException, new()
        {
            if (model == null)
            {
                Thrower.Throw<TException>(CannotRemoveItemTemplate, typeof(TDomainModel).Name);
            }

            collection.Remove(model);
            return model;
        }

        public static TDomainModel CheckExistingAndAdd<TDomainModel, TException>(
            this ICollection<TDomainModel> collection,
            TDomainModel entity)
            where TDomainModel : IDomainModel
            where TException : DomainException, new()
        {
            if (collection.Any(x => x.Id != default && x.Id == entity.Id))
            {
                Thrower.Throw<TException>(CannotAddItemTemplate, typeof(TDomainModel).Name, entity.Id);
            }

            collection.Add(entity);
            return entity;
        }
    }
}
