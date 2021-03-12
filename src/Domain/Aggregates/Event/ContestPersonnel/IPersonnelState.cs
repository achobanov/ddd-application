using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel
{
    public interface IPersonnelState : IDomainModelState
    {
        public string Name { get; }
    }
}
