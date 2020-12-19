using System;
using EnduranceContestManager.Common.ConventionalServices;

namespace EnduranceContestManager.Common.Contracts
{
    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}
