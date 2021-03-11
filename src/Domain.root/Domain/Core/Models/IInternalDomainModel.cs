using System;

namespace EnduranceContestManager.Domain.Core.Models
{
    internal interface IInternalDomainModel : IDomainModel
    {
        void Validate(Action action);
    }
}
