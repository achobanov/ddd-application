using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Linq;
using static EnduranceContestManager.Domain.DomainConstants;

namespace EnduranceContestManager.Domain.Validation
{
    public static class StringValidations
    {
        private const string Template = "has invalid name '{0}'. Must contain first and last name.";
        private const string PersonNameLabel = "Person name";
        private const string InvalidGenderTemplate = "has invalid gender: '{0}'";

        public static string CheckPersonName(this string text)
        {
            var name = text.CheckNotDefault(PersonNameLabel);

            var parts = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var firstName = parts.FirstOrDefault();
            var lastName = parts.LastOrDefault();

            if (parts.Length < 2 || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ValidationException(Template, name);
            }

            return name;
        }

        public static string CheckValidGender(this string value)
        {
            if (value != Gender.Female && value != Gender.Male)
            {
                throw new ValidationException(InvalidGenderTemplate, value);
            }

            return value;
        }
    }
}
