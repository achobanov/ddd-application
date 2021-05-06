using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Domain.Aggregates.Import.Athletes
{
    public interface IAthleteState : IDomainModelState
    {
        public string FeiId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Category Category { get; }
    }
}
