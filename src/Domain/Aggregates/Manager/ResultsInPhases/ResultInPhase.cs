using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Manager.ResultsInPhases
{
    public class ResultInPhase : DomainModel<ManagerResultInPhaseException>, IResultInPhaseState,
        IDependsOn<ParticipationInPhase>
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

        public ParticipationInPhase ParticipationInPhase { get; private set; }

        void IDependsOn<ParticipationInPhase>.Set(ParticipationInPhase domainModel)
            => this.Validate(() =>
            {
                this.ParticipationInPhase.IsNotRelated();
                this.ParticipationInPhase = domainModel;
            });

        public void Clear(ParticipationInPhase domainModel)
        {
            this.ParticipationInPhase = null;
        }
    }
}