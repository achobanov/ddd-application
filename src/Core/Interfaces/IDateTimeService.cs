using System;
using EnduranceJudge.Core.ConventionalServices;

namespace EnduranceJudge.Core.Interfaces
{
    public interface IDateTimeService : IService
    {
        DateTime Now { get; }
    }
}
