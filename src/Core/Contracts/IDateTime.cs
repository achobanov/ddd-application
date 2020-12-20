using System;
using EnduranceContestManager.Core.ConventionalServices;

namespace EnduranceContestManager.Core.Contracts
{
    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}
