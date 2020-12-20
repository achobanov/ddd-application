using System;

namespace EnduranceContestManager.Core.Contracts.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
