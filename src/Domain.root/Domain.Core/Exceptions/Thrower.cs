namespace EnduranceContestManager.Domain.Core.Exceptions
{
    public static class Thrower
    {
        public static void Throw<TException>(string message)
            where TException : DomainException, new()
        {
            InnerThrow<TException>(message);
        }

        public static void Throw<TException>(string template, params object[] arguments)
            where TException : DomainException, new()
        {
            InnerThrow<TException>(template, arguments);
        }

        private static void InnerThrow<TException>(string template, object[] arguments = null)
            where TException : DomainException, new()
        {
            var exception = new TException
            {
                Template = template
            };

            if (arguments != null)
            {
                exception.WithArguments(arguments);
            }

            throw exception;
        }
    }
}
