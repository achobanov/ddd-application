using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Linq;

namespace EnduranceContestManager.Domain.Validation
{
    public static class StringValidations
    {
        private const string Template = "Invalid name '{0}'";
        private const string PersonNameLabel = "Person name";

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
    }
}
