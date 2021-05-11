using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;
using static EnduranceJudge.Localization.Strings.DomainStrings;

namespace EnduranceJudge.Domain.Core.Validation
{
    public static class ValidationExtensions
    {
        public static TValue IsRequired<TValue>(this TValue value, string name)
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                throw new ValidationException(IsRequiredTemplate, name, value);
            }

            return value;
        }

        public static TValue IsNotDefault<TValue>(this TValue value, string name)
        {
            if (value?.Equals(default(TValue)) ?? true)
            {
                throw new ValidationException(IsRequiredTemplate, name);
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
