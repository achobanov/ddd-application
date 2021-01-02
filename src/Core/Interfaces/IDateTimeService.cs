using System;
using EnduranceContestManager.Core.ConventionalServices;

namespace EnduranceContestManager.Core.Interfaces
{
    public interface IDateTimeService : IService
    {
        DateTime Now { get; }
    }
}
