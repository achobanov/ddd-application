using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Linq;

namespace EnduranceContestManager.Domain.Validation
{
    public static class PersonNameValidation<TException>
        where TException : DomainException, new()
    {
        private const string Template = "Invalid name '{0}'";

        public static string Validate(string name)
        {
            NotDefaultValidation<TException>.Validate(name, nameof(name));

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
