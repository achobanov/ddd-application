using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
{
    public interface IResultInPhaseState : IDomainModelState
    {
        bool IsRanked { get; }

        string Code { get; }
    }
}
