using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
{
    public interface IResultInPhaseState : IDomainModelState
    {
        bool IsRanked { get; }

        bool IsQualified { get; }

        string Code { get; }
    }
}
