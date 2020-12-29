using System;

namespace EnduranceContestManager.Core.Interfaces.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
