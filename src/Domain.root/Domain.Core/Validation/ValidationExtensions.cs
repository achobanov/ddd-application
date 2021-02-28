using EnduranceContestManager.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Core.Validation
{
    public static class ValidationExtensions
    {
        private const string EntityIsAlreadyRelatedTemplate = "is already related to '{0}' with id: '{1}'";
        private const string NotDefaultTemplate = "property '{0}' is required.";
        private const string CannotRemoveNullItemTemplate = "cannot remove '{0}' - it is null.";
        private const string CannotRemoveItemIsNotFoundTemplate = "cannot remove '{0}' - it is not found.";
        private const string CannotAddNullItemTemplate = "cannot add '{0}' because entity with Id '{1}' already exists.";
        private const string CannotAddItemExistsTemplate = "cannot add '{0}' because entity with Id '{1}' already exists.";

        public static void IsNotRelated<TDomainModel>(this TDomainModel model)
            where TDomainModel : IDomainModel
        {
            if (!model?.Equals(default(TDomainModel)) ?? false)
            {
                throw new ValidationException(EntityIsAlreadyRelatedTemplate, typeof(TDomainModel).Name, model.Id);
            }
        }

        public static TValue IsRequired<TValue>(this TValue value, string name)
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                throw new ValidationException(NotDefaultTemplate, name, value);
            }

            return value;
        }

        public static TValue IsNotDefault<TValue>(this TValue value, string message)
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                throw new ValidationException(message);
            }

            return value;
        }

        public static TValue IsDefault<TValue>(this TValue value, string message)
        {
            if (!value?.Equals(default(TValue)) ?? false)
            {
                throw new ValidationException(message);
            }

            return value;
        }

        public static void IsNotEmpty<TValue>(this IEnumerable<TValue> enumerable, string message)
        {
            if (!enumerable.Any())
            {
                throw new ValidationException(message);
            }
        }

        public static void IsEmpty<TValue>(this IEnumerable<TValue> enumerable, string message)
        {
            if (enumerable.Any())
            {
                throw new ValidationException(message);
            }
        }

        public static TDomainModel ValidateAndRemove<TDomainModel>(
            this ICollection<TDomainModel> collection,
            TDomainModel model)
            where TDomainModel : IDomainModel
        {
            if (model == null)
            {
                throw new ValidationException(CannotRemoveNullItemTemplate, typeof(TDomainModel).Name);
            }

            if (!collection.Contains(model))
            {
                throw new ValidationException(CannotRemoveItemIsNotFoundTemplate, typeof(TDomainModel).Name);
            }

            collection.Remove(model);
            return model;
        }

        public static TDomainModel ValidateAndAdd<TDomainModel>(
            this ICollection<TDomainModel> collection,
            TDomainModel model)
            where TDomainModel : IDomainModel
        {
            if (model == null)
            {
                throw new ValidationException(CannotAddNullItemTemplate, typeof(TDomainModel).Name);
            }

            if (collection.Contains(model))
            {
                throw new ValidationException(CannotAddItemExistsTemplate, typeof(TDomainModel).Name, model.Id);
            }

            collection.Add(model);
            return model;
        }
    }
}
