using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Models;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
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
