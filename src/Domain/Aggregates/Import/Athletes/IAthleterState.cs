using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;
using System;

namespace EnduranceJudge.Domain.Aggregates.Import.Athletes
{
    public interface IAthleteState : IDomainModelState
    {
        public string FeiId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Gender { get; }

        public DateTime BirthDate { get; }

        public Category Category { get; }
    }
}
