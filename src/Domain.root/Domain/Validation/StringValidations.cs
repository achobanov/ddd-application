using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Linq;
using static EnduranceContestManager.Domain.DomainConstants;

namespace EnduranceContestManager.Domain.Validation
{
    public static class StringValidations
    {
        private const string Template = "Invalid name '{0}'";
        private const string PersonNameLabel = "Person name";
        private const string InvalidGenderTemplate = "Invalid gender: '{0}'";

        public static string CheckPersonName<TException>(this string text)
            where TException : DomainException, new()
        {
            var name = text.CheckNotDefault<string, TException>(PersonNameLabel);

            var parts = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var firstName = parts.FirstOrDefault();
            var lastName = parts.LastOrDefault();

            if (parts.Length < 2 && firstName == null && lastName == null)
            {
                Thrower.Throw<TException>(Template, name);
            }

            return name;
        }

        public static string CheckValidGender<TException>(this string value)
            where TException : DomainException, new()
        {
            if (value != Gender.Female && value != Gender.Male)
            {
                Thrower.Throw<TException>(InvalidGenderTemplate, value);
            }

            return value;
        }
    }
}
