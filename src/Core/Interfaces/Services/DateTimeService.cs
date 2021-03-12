using System;

namespace EnduranceJudge.Core.Interfaces.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
