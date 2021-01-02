using System;

namespace EnduranceContestManager.Core.Interfaces.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
