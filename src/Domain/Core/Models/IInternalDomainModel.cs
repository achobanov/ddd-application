using System;

namespace EnduranceJudge.Domain.Core.Models
{
    internal interface IInternalDomainModel : IDomainModel
    {
        void Validate(Action action);
    }
}
