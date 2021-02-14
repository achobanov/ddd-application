using EnduranceContestManager.Domain.Core.Entities;
using System;

namespace EnduranceContestManager.Domain
{
    internal interface IInternalDomainModel : IDomainModel
    {
        void Except(Action action);
    }
}
