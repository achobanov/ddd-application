using EnduranceContestManager.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Core.Validation
{
    public static class ValidationExtensions
    {
        private const string EntityIsAlreadyRelatedTemplate = "is already related to '{0}' with id: '{1}'";
        private const string NotDefaultTemplate = "property '{0}' is required.";
        private const string CannotRemoveItemTemplate = "cannot remove {0} because it is not found.";
        private const string CannotAddItemTemplate = "cannot add {0} because entity with Id '{1}' already exists.";

        public static void CheckNotRelated<TDomainModel>(this TDomainModel model)
            where TDomainModel : IDomainModel
        {
            if (!model?.Equals(default(TDomainModel)) ?? false)
            {
                throw new ValidationException(EntityIsAlreadyRelatedTemplate, typeof(TDomainModel).Name, model.Id);
            }
        }

        public static TValue CheckNotDefault<TValue>(this TValue value, string name)
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                throw new ValidationException(NotDefaultTemplate, name, value);
            }

            return value;
        }

        public static TDomainModel CheckNotExistingAndRemove<TDomainModel>(
            this ICollection<TDomainModel> collection,
            TDomainModel model)
            where TDomainModel : IDomainModel
        {
            if (model == null)
            {
                throw new ValidationException(CannotRemoveItemTemplate, typeof(TDomainModel).Name);
            }

            collection.Remove(model);
            return model;
        }

        public static TDomainModel CheckExistingAndAdd<TDomainModel>(
            this ICollection<TDomainModel> collection,
            TDomainModel entity)
            where TDomainModel : IDomainModel
        {
            if (collection.Any(x => x.Id != default && x.Id == entity.Id))
            {
                throw new ValidationException(CannotAddItemTemplate, typeof(TDomainModel).Name, entity.Id);
            }

            collection.Add(entity);
            return entity;
        }
    }
}
