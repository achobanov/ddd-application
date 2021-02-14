using EnduranceContestManager.Domain.Core.Exceptions;
using System;

namespace EnduranceContestManager.Domain.Validation
{
    public static class DateTimeValidations
    {
        private const string InvalidBirthDateTemplate = "Invalid birth date: {0}";

        public static DateTime CheckDatePassed<TException>(this DateTime dateTime)
            where TException : DomainException, new()
        {
            if (dateTime >= DateTime.Now)
            {
                Thrower.Throw<TException>(InvalidBirthDateTemplate, dateTime);
            }

            return dateTime;
        }
    }
}
