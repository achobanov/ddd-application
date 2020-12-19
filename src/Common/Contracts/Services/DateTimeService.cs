using System;

namespace EnduranceContestManager.Common.Contracts.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
