using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ResultsInPhases
{
    public class ResultInPhase : DomainModel<ManagerResultInPhaseException>, IResultInPhaseState,
        IDependsOn<ParticipationInPhase>
    {
        internal ResultInPhase() : base(default)
        {
            this.IsQualified = true;
            this.IsRanked = true;
        }

        internal ResultInPhase(string code, bool isRanked, bool isQualified) : base(default)
        {
            this.Code = code; // TODO: Validate code
            this.IsRanked = isRanked;
            this.IsQualified = isQualified;
        }

        public bool IsRanked { get; private set; }
        // TODO: Remove this
        public bool IsQualified { get; private set; }
        public string Code { get; private set; }

        public ParticipationInPhase ParticipationInPhase { get; private set; }

        public bool IsSuccessful
        {
            get
            {
                return this.IsRanked && this.IsQualified;
            }
        }

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
