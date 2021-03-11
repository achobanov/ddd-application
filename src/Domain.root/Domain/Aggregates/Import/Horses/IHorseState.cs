using EnduranceContestManager.Domain.Core.Models;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Import.Horses
{
    public interface IHorseState : IDomainModelState
    {
        string Name { get; }

        string Gender { get; }

        bool IsStallion { get; }

        DateTime BirthDay { get; }

        string Owner { get; }
    }
}
