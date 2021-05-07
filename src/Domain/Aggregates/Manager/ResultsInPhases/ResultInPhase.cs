using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Manager.ResultsInPhases
{
    public class ResultInPhase : DomainModel<ManagerResultInPhaseException>, IResultInPhaseState
    {
        internal ResultInPhase() : base(default)
        {
            this.IsRanked = true;
        }

        internal ResultInPhase(string code) : base(default)
        {
            this.Code = code;
            this.IsRanked = false;
        }

        public bool IsRanked { get; private set; }
        public string Code { get; private set; }
    }
}
