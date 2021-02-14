using EnduranceContestManager.Domain.Core.Entities;
using System;

namespace EnduranceContestManager.Domain.Models.ImportAggregate.Riders
{
    public interface IRiderState : IDomainModelState
    {
        public int FeiId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Gender { get; }

        public DateTime BirthDate { get; }

        public string Country { get; }
    }
}
