using System;
using EnduranceContestManager.Core.ConventionalServices;

namespace EnduranceContestManager.Core.Interfaces
{
    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}
