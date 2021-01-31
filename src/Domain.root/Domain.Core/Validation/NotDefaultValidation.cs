using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Core.Validation
{
    public class NotDefaultValidation<TException>
        where TException : DomainException, new()
    {
        private const string Template = "Property '{0}' cannot be '{1}'";

        public static T Validate<T>(T value, string name)
        {
            if (value?.Equals(default(T)) ?? true)
            {
                Thrower.Throw<TException>(Template, name, value);
            }

            return value;
        }
    }
}
