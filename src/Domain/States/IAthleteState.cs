using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Domain.States
{
    public interface IAthleteState : IDomainModel
    {
        public Category Category { get; }
    }
}
