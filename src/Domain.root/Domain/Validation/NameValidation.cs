using System;
using System.Linq;

namespace EnduranceContestManager.Domain.Validation
{
    public static class NameValidation
    {
        public static string Validate(string name)
        {
            var parts = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var firstName = parts.FirstOrDefault();
            var lastName = parts.LastOrDefault();

            if (parts.Length < 2 || firstName == null || lastName == null)
            {
                throw new Exception();
            }

            return name;
        }
    }
}
