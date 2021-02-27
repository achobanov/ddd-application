using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Runtime.CompilerServices;

namespace EnduranceContestManager.Domain.Validation
{
    public static class DateTimeValidations
    {
        private const string InvalidBirthDateTemplate = "has invalid birth date: {0}";

        public static DateTime? HasDatePassed(this DateTime? dateTime)
        {
            return dateTime?.HasDatePassed();
        }

        public static DateTime HasDatePassed(this DateTime dateTime)
        {
            if (dateTime >= DateTime.Now)
            {
                throw new ValidationException(InvalidBirthDateTemplate, dateTime);
            }

            return dateTime;
        }
    }
}
