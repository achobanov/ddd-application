using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInTrials
{
    public class Participant : DomainModel<ParticipationInTrialException>,
        IDependsOn<ParticipationInTrial>
    {
        public Participant(int id) : base(id)
        {
        }

        public ParticipationInTrial ParticipationInTrial { get; private set; }
        void IDependsOn<ParticipationInTrial>.Set(ParticipationInTrial domainModel)
            => this.Validate(() =>
            {
                this.ParticipationInTrial.IsNotRelated();
                this.ParticipationInTrial = domainModel;
            });
        void IDependsOn<ParticipationInTrial>.Clear(ParticipationInTrial domainModel)
        {
            this.ParticipationInTrial = null;
        }
    }
}
