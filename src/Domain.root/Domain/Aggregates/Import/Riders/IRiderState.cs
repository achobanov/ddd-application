using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Enums;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Import.Riders
{
    public interface IRiderState : IDomainModelState
    {
        public string FeiId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Gender { get; }

        public DateTime BirthDate { get; }

        public Category Category { get; }
    }
}
