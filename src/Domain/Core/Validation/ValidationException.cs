using System;

namespace EnduranceJudge.Domain.Core.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string template, params object[] arguments)
            : base(string.Format(template, arguments))
        {
        }
    }
}
